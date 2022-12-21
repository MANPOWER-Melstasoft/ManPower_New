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
    public interface LeaveTypeController
    {
        List<LeaveType> GetAllLeaveTypes();
        LeaveType GetLeaveTypeById(int id);
    }
    public class LeaveTypeControllerImpl : LeaveTypeController
    {
        public List<LeaveType> GetAllLeaveTypes()
        {
            DBConnection dBConnection = new DBConnection();
            LeaveTypeDAO leaveTypeDAO = DAOFactory.CreateLeaveTypeDAO();
            try
            {

                List<LeaveType> list = leaveTypeDAO.GetAllLeaveTypes(dBConnection);
                return list;
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
        public LeaveType GetLeaveTypeById(int id)
        {
            LeaveTypeDAO leaveTypeDAO = DAOFactory.CreateLeaveTypeDAO();
            DBConnection dBConnection = new DBConnection();
            try
            {

                LeaveType leaveType = leaveTypeDAO.GetLeaveTypeById(id, dBConnection);
                return leaveType;
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
