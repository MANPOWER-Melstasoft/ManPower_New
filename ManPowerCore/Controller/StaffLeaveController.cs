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
    public interface StaffLeaveController
    {
        int saveStaffLeave(StaffLeave staffLeave);
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
    }
}
