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
            int id = 2;

            try
            {
                dBConnection = new DBConnection();
                //id = employeeDAO.SaveEmployee(emp, dBConnection);

                if (emp._EmployeeContact.Count > 0)
                {
                    foreach (var item in emp._EmployeeContact)
                    {
                        item.EmpID = id;
                        employeeContactDAO.SaveEmployeeContact(item, dBConnection);
                    }
                }

                if (emp._EmploymentDetails.Count > 0)
                {
                    foreach (var item in emp._EmploymentDetails)
                    {
                        item.EmpID = id;
                        employmentDetailsDAO.SaveEmploymentDetails(item, dBConnection);
                    }
                }

                if (emp._Dependant.Count > 0)
                {
                    foreach (var item in emp._Dependant)
                    {
                        item.EmpId = id;
                        dependentDAO.SaveDependant(item, dBConnection);
                    }
                }

                if (emp._EducationDetails.Count > 0)
                {
                    foreach (var item in emp._EducationDetails)
                    {
                        item.EmployeeId = id;
                        educationDetailsDAO.SaveEducationDetails(item, dBConnection);
                    }
                }

                if (emp._EmployeeServices.Count > 0)
                {
                    foreach (var item in emp._EmployeeServices)
                    {
                        item.EmpId = id;
                        employeeServicesDAO.SaveEmployeeServices(item, dBConnection);
                    }
                }

                if(id != 0)
                {
                    emp._EmergencyContact.EmployeeId = id;
                    emergencyContactDAO.SaveEmergencyContact(emp._EmergencyContact, dBConnection);
                }
                

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


    }

}

