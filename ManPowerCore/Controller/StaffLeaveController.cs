using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface StaffLeaveController
    {
        int saveStaffLeave(StaffLeave staffLeave);

        int saveStaffLeaveDoc(StaffLeave staffLeave);

        List<StaffLeave> getStaffLeaves(bool withEmployeeDetails);

        List<StaffLeave> getStaffLeavesSummary(bool withEmployeeDetails);

        int updateStaffLeaves(StaffLeave staffLeave);

        int updateStaffLeaveRecommendation(StaffLeave staffLeave);

        int updateStaffLeavesSubmit(StaffLeave staffLeave);

        StaffLeave getStaffLeaveById(int id);
        Employee GetemployeeDetailsByEmployeeId(int EmployeeId);

        decimal getRemainLeaveByEmpAndYear(int Emp, int Year, int LeaveType);
    }
    public class StaffLeaveControllerImpl : StaffLeaveController
    {
        DBConnection dBConnection;
        StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
        public int saveStaffLeave(StaffLeave staffLeave)
        {

            try
            {
                int output = 0;
                dBConnection = new DBConnection();
                output = staffLeaveDAO.saveStaffLeave(staffLeave, dBConnection);

                if (output > 0)
                {
                    StaffLeaveDocumentsDAO staffLeaveDocumentsDAO = DAOFactory.CreateStaffLeaveDocumentsDAO();
                    foreach (var item in staffLeave.documents)
                    {
                        item.StaffLeaveId = output;
                        staffLeaveDocumentsDAO.Save(item, dBConnection);
                    }
                }

                return output;


            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int saveStaffLeaveDoc(StaffLeave staffLeave)
        {

            try
            {
                dBConnection = new DBConnection();
                return staffLeaveDAO.saveStaffLeaveDoc(staffLeave, dBConnection);


            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public Employee GetemployeeDetailsByEmployeeId(int EmployeeId)
        {
            try
            {
                dBConnection = new DBConnection();
                EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
                Employee employee = new Employee();
                employee = employeeDAO.GetEmployeeById(EmployeeId, dBConnection);
                return employee;



            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<StaffLeave> getStaffLeaves(bool withEmployeeDetails)
        {
            try
            {
                dBConnection = new DBConnection();
                staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                List<StaffLeave> staffLeavesList = new List<StaffLeave>();

                staffLeavesList = staffLeaveDAO.getStaffLeaves(dBConnection);

                if (withEmployeeDetails)
                {
                    EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
                    SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();
                    DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();

                    foreach (var items in staffLeavesList)
                    {
                        items._EMployeeDetails = employeeDAO.GetEmployeeById(items.EmployeeId, dBConnection);
                        items.systemUser = systemUserDAO.CheckEmpNumberExists(items.EmployeeId, dBConnection);
                        if (items.LeaveStatusId == 4)
                        {
                            items.recommendUser = systemUserDAO.GetSystemUser(items.RecommendedBy, dBConnection);
                            items.approveUser = systemUserDAO.GetSystemUser(items.ApprovedBy, dBConnection);
                        }
                        items.district = departmentUnitDAO.GetDepartmentUnit(items._EMployeeDetails.DistrictId, dBConnection);
                        if (items._EMployeeDetails.UnitType == 3)
                        {
                            items.dsDivition = departmentUnitDAO.GetDepartmentUnit(items._EMployeeDetails.DSDivisionId, dBConnection);
                        }
                        else
                        {
                            items.dsDivition = new DepartmentUnit() { Name = "" };
                        }
                    }

                }

                return staffLeavesList;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }


        public List<StaffLeave> getStaffLeavesSummary(bool withEmployeeDetails)
        {
            try
            {
                dBConnection = new DBConnection();
                staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                List<StaffLeave> staffLeavesList = new List<StaffLeave>();
                List<StaffLeave> staffLeavesListLoop = new List<StaffLeave>();
                List<StaffLeave> staffLeavesListFinal = new List<StaffLeave>();

                staffLeavesList = staffLeaveDAO.getStaffLeaves(dBConnection);
                var EmpId = staffLeavesList.Select(x => x.EmployeeId).Distinct();

                foreach (var emp in EmpId)
                {
                    StaffLeave staffLeavesObj = new StaffLeave();
                    int flag = 0;
                    staffLeavesListLoop = staffLeavesList.Where(x => x.EmployeeId == emp).ToList();
                    foreach (var item in staffLeavesListLoop)
                    {
                        if (item.LeaveStatusId == 4)
                        {
                            flag = 1;
                            staffLeavesObj.StaffLeaveId = item.StaffLeaveId;
                            staffLeavesObj.EmployeeId = item.EmployeeId;
                            staffLeavesObj.NoOfLeaves += item.NoOfLeaves;
                            staffLeavesObj.LeaveStatusId = item.LeaveStatusId;
                        }
                    }
                    if (flag == 1)
                    {
                        staffLeavesListFinal.Add(staffLeavesObj);
                    }
                }

                if (withEmployeeDetails)
                {
                    EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
                    SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();
                    DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();

                    foreach (var items in staffLeavesListFinal)
                    {
                        items._EMployeeDetails = employeeDAO.GetEmployeeById(items.EmployeeId, dBConnection);
                        items.systemUser = systemUserDAO.CheckEmpNumberExists(items.EmployeeId, dBConnection);
                        items.district = departmentUnitDAO.GetDepartmentUnit(items._EMployeeDetails.DistrictId, dBConnection);
                        if (items._EMployeeDetails.UnitType == 3)
                        {
                            items.dsDivition = departmentUnitDAO.GetDepartmentUnit(items._EMployeeDetails.DSDivisionId, dBConnection);
                        }
                        else
                        {
                            items.dsDivition = new DepartmentUnit() { Name = "" };
                        }
                    }

                }

                return staffLeavesListFinal;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }


        }


        public int updateStaffLeaves(StaffLeave staffLeave)
        {
            try
            {
                dBConnection = new DBConnection();
                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();

                if (staffLeave.LeaveStatusId == 3 || staffLeave.LeaveStatusId == 7 || staffLeave.LeaveStatusId == 8
                    || staffLeave.LeaveStatusId == 9 || staffLeave.LeaveStatusId == 10)
                {
                    return staffLeaveDAO.updateStaffLeaveRecommendation(staffLeave, dBConnection);
                }
                else if (staffLeave.LeaveStatusId == 5)
                {
                    return staffLeaveDAO.updateStaffLeaveReject(staffLeave, dBConnection);
                }
                else
                {
                    return staffLeaveDAO.updateStaffLeave(staffLeave, dBConnection);
                }
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int updateStaffLeaveRecommendation(StaffLeave staffLeave)
        {
            try
            {
                dBConnection = new DBConnection();
                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                return staffLeaveDAO.updateStaffLeaveRecommendation(staffLeave, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int updateStaffLeavesSubmit(StaffLeave staffLeave)
        {

            try
            {
                dBConnection = new DBConnection();
                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                return staffLeaveDAO.updateStaffLeaveSubmit(staffLeave, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public StaffLeave getStaffLeaveById(int id)
        {
            StaffLeave staffLeave = new StaffLeave();
            try
            {
                dBConnection = new DBConnection();

                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                staffLeave = staffLeaveDAO.getStaffLeaveById(id, dBConnection);
                return staffLeave;



            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public decimal getRemainLeaveByEmpAndYear(int Emp, int Year, int LeaveType)
        {
            try
            {
                dBConnection = new DBConnection();
                DataTable dataTable = new DataTable();
                decimal remain = 0;
                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
                dataTable = staffLeaveDAO.getRemainLeaveByEmpAndYear(Emp, Year, LeaveType, dBConnection);

                foreach (DataRow row in dataTable.Rows)
                {
                    remain = Convert.ToDecimal(row["Balance"].ToString());
                    string val = row["Balance"].ToString();
                }

                return remain;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}
