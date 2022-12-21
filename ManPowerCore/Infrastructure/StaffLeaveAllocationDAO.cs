using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface StaffLeaveAllocationDAO
    {
        int saveStaffLeaveAllocation(StaffLeaveAllocation staffLeaveAllocation, DBConnection dBConnection);
    }

    public class StaffLeaveAllocationDAOSqlImpl : StaffLeaveAllocationDAO
    {
        public int saveStaffLeaveAllocation(StaffLeaveAllocation staffLeaveAllocation, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.CommandType = System.Data.CommandType.Text;
            dBConnection.cmd.CommandText = "INSERT INTO Staff_Leave_Allocation (Employee_ID,Leave_Type_id,Leave_Year,No_Of_Days,Entitlement,Month_Limit,Month_Limit_Applied_To)" +
                " VALUES(@EMPID,@LeaveTypeId,@LYear,@NoOfDays,@Entitlement,@MonthLimit,@AppliedTo);";

            dBConnection.cmd.Parameters.AddWithValue("@EMPID", staffLeaveAllocation.EmployeesID);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveTypeId", staffLeaveAllocation.LeaveTypeId);

            dBConnection.cmd.Parameters.AddWithValue("@LYear", staffLeaveAllocation.LeaveYear);

            dBConnection.cmd.Parameters.AddWithValue("@NoOfDays", staffLeaveAllocation.NoOfDays);

            dBConnection.cmd.Parameters.AddWithValue("@Entitlement", staffLeaveAllocation.Entitlement);

            dBConnection.cmd.Parameters.AddWithValue("@MonthLimit", staffLeaveAllocation.MonthLimit);
            dBConnection.cmd.Parameters.AddWithValue("@AppliedTo", staffLeaveAllocation.MonthLimitAppliedTo);


            return dBConnection.cmd.ExecuteNonQuery();
        }
    }
}
