using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
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

        int updateStaffLeaves(StaffLeave staffLeave);
        StaffLeave getStaffLeaveById(int id);
        Employee GetemployeeDetailsByEmployeeId(int EmployeeId);
    }
    public class StaffLeaveControllerImpl : StaffLeaveController
    {
        DBConnection dBConnection;
        StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();
        public int saveStaffLeave(StaffLeave staffLeave)
        {

            try
            {
                dBConnection = new DBConnection();
                return staffLeaveDAO.saveStaffLeave(staffLeave, dBConnection);


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

                    foreach (var items in staffLeavesList)
                    {
                        items._EMployeeDetails = employeeDAO.GetEmployeeById(items.EmployeeId, dBConnection);
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

        public int updateStaffLeaves(StaffLeave staffLeave)
        {

            try
            {
                dBConnection = new DBConnection();

                StaffLeaveDAO staffLeaveDAO = DAOFactory.CreateStaffLeaveDAO();

                if (staffLeave.LeaveStatusId == 2)
                {
                    return staffLeaveDAO.updateStaffLeaveRecommendation(staffLeave, dBConnection);

                }
                else if (staffLeave.LeaveStatusId == -1)
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
    }
}
