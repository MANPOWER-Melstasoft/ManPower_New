using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface EmployeeController
    {
        int SaveEmployee(Employee emp);
        List<Employee> GetAllEmployees();

        List<Employee> GetAllEmployees(bool withEmployeeDetails);

        Employee GetEmployeeById(int id);

        int UpdateEmployee(Employee emp);

        int AcInAcEmployee(int EmpId, int isActive);
    }

    public class EmployeeControllerImpl : EmployeeController
    {
        DBConnection dBConnection;

        EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
        EmployeeContactDAO employeeContactDAO = DAOFactory.CreateEmployeeContactDAO();
        EmploymentDetailsDAO employmentDetailsDAO = DAOFactory.CreateEmploymentDetailsDAO();
        DependentDAO dependentDAO = DAOFactory.CreateDependentDAO();
        EducationDetailsDAO educationDetailsDAO = DAOFactory.CreateEducationDetailsDAO();
        EmergencyContactDAO emergencyContactDAO = DAOFactory.CreateEmergencyContactDAO();
        EmployeeServicesDAO employeeServicesDAO = DAOFactory.CreateEmployeeServicesDAO();

        public int SaveEmployee(Employee emp)
        {
            int id = 0;

            try
            {
                dBConnection = new DBConnection();
                id = employeeDAO.SaveEmployee(emp, dBConnection);

                if (emp._EmploymentDetails != null)
                {
                    foreach (var item in emp._EmploymentDetails)
                    {
                        item.EmpID = id;
                        employmentDetailsDAO.SaveEmploymentDetails(item, dBConnection);
                    }
                }

                if (emp._Dependant != null)
                {
                    foreach (var item in emp._Dependant)
                    {
                        item.EmpId = id;
                        if (item.DependantTypeId == 1)
                        {
                            dependentDAO.SaveDependantSpouse(item, dBConnection);
                        }
                        else
                        {
                            dependentDAO.SaveDependantOther(item, dBConnection);
                        }

                    }
                }

                if (emp._EducationDetails != null)
                {
                    foreach (var item in emp._EducationDetails)
                    {
                        item.EmployeeId = id;
                        educationDetailsDAO.SaveEducationDetails(item, dBConnection);
                    }
                }

                if (emp._EmployeeServices != null)
                {

                    foreach (var item in emp._EmployeeServices)
                    {
                        item.EmpId = id;
                        employeeServicesDAO.SaveEmployeeServices(item, dBConnection);
                    }
                }


                if (emp._EmployeeContact != null)
                {
                    emp._EmployeeContact.EmpID = id;
                    employeeContactDAO.SaveEmployeeContact(emp._EmployeeContact, dBConnection);
                }

                //if (emp._EmergencyContact != null)
                //{
                //    emp._EmergencyContact.EmployeeId = id;
                //    emergencyContactDAO.SaveEmergencyContact(emp._EmergencyContact, dBConnection);
                //}


                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
        public List<Employee> GetAllEmployees()
        {
            DBConnection dBConnection = new DBConnection();
            EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
            try
            {
                List<Employee> employeesList = employeeDAO.GetAllEmployee(dBConnection);

                DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
                List<DepartmentUnit> departmentUnitsList = departmentUnitDAO.GetAllDepartmentUnit(dBConnection);

                foreach (var item in employeesList)
                {
                    item.fullName = item.EmpInitials + " " + item.LastName;
                    if (item.UnitType == 3)
                    {
                        item._DepartmentUnit = departmentUnitsList.Where(x => x.DepartmentUnitId == item.DSDivisionId).Single();
                    }
                    else
                    {
                        item._DepartmentUnit = departmentUnitsList.Where(x => x.DepartmentUnitId == item.DistrictId).Single();
                    }
                }

                return employeesList;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
        public List<Employee> GetAllEmployees(bool withEmployeeDetails)
        {
            DBConnection dBConnection = new DBConnection();
            EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
            try
            {
                List<Employee> employeesList = employeeDAO.GetAllEmployee(dBConnection);
                List<EmploymentDetails> employeeDetailList = new List<EmploymentDetails>();


                if (withEmployeeDetails)
                {
                    EmploymentDetailsDAO employmentDetailsDAO = DAOFactory.CreateEmploymentDetailsDAO();
                    employeeDetailList = employmentDetailsDAO.GetAllEmploymentDetails(dBConnection);

                    foreach (var item in employeesList)
                    {
                        item.fullName = item.EmpInitials + " " + item.LastName;

                        foreach (var itemIn in employeeDetailList)
                        {
                            if (itemIn.EmpID == item.EmployeeId)
                            {
                                item._EmploymentDetailsSingle = itemIn;
                                break;
                            }
                        }
                    }

                }
                return employeesList;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            DBConnection dBConnection = new DBConnection();
            EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
            try
            {
                Employee employee = employeeDAO.GetEmployeeById(id, dBConnection);
                employee.fullName = employee.EmpInitials + " " + employee.LastName;

                return employee;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateEmployee(Employee emp)
        {
            try
            {
                dBConnection = new DBConnection();

                //-------------get system user ID --------------------------
                SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();
                SystemUser systemUser = systemUserDAO.CheckEmpNumberExists(emp.EmployeeId, dBConnection);

                if (systemUser.SystemUserId != 0)
                {
                    //--------------check if department has changed ---------------------------------
                    Employee employeeOld = employeeDAO.GetEmployeeById(emp.EmployeeId, dBConnection);

                    if (employeeOld.UnitType != emp.UnitType || employeeOld.DistrictId != emp.DistrictId || employeeOld.DSDivisionId != emp.DSDivisionId)
                    {
                        DesignationDAO designationDAO = DAOFactory.CreateDesignationDAO();
                        DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();

                        systemUser._Designation = designationDAO.GetDesignation(systemUser.DesignationId, dBConnection);
                        systemUser._DepartmentUnitPositions = departmentUnitPositionsDAO.GetAllDepartmentUnitPositionsBySystemUserId(systemUser.SystemUserId, dBConnection);


                        //------------------------------------ get parent id -------------------------------------------------------------------------
                        int parentId = 0;
                        int userType = systemUser.UserTypeId;
                        int depType = emp.UnitType;
                        int depId;
                        if (depType == 3)
                        {
                            depId = emp.DSDivisionId;
                        }
                        else
                        {
                            depId = emp.DistrictId;
                        }

                        DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
                        List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

                        if (userType == 1 || (userType == 2 && depType == 1))
                        {
                            parentId = 0;
                        }
                        if (userType == 3 && (depType == 1 || depType == 2 || depType == 3))
                        {
                            foreach (var x in departmentUnitPositionsList)
                            {
                                if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 2)
                                {
                                    parentId = x.DepartmetUnitPossitionsId;
                                }
                            }
                            //if (parentId == 0)
                            //{
                            //    lblManagerError.Text = "There is no Manager to this Unit!";
                            //}
                        }
                        if (userType == 2 && (depType == 2 || depType == 3))
                        {
                            DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
                            List<DistricDsParent> districDsParentList = districDsParentController.GetAllDistricDsParent(false, false);
                            int userId = 0;
                            foreach (var x in districDsParentList)
                            {
                                if (x.DepartmentId == depId)
                                {
                                    userId = x.ParentUserId;
                                }
                            }
                            if (userId != 0)
                            {
                                foreach (var x in departmentUnitPositionsList)
                                {
                                    if (x.SystemUserId == userId)
                                    {
                                        parentId = x.DepartmetUnitPossitionsId;
                                    }
                                }
                            }
                            //else
                            //{
                            //    lblManagerError.Text = "There is no Manager to this Unit!";
                            //}
                        }
                        //------------------------------------ end get parent id -------------------------------------------------------------------------



                        //----------------------------------------- update parent ---------------------------------------------------
                        systemUser._DepartmentUnitPositions.ParentId = parentId;
                        systemUser._DepartmentUnitPositions.DepartmentUnitId = depId;

                        departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(systemUser._DepartmentUnitPositions, dBConnection);
                    }
                }


                //------------------update employee------------------------
                int results = employeeDAO.UpdateEmployee(emp, dBConnection);

                return results;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }



        public int AcInAcEmployee(int EmpId, int isActive)
        {
            try
            {
                dBConnection = new DBConnection();
                int results = employeeDAO.AcInAcEmployee(EmpId, isActive, dBConnection);

                return results;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

    }
}

