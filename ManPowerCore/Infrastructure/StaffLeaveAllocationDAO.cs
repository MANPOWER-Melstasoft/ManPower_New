using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface StaffLeaveAllocationDAO
    {
        int saveStaffLeaveAllocation(StaffLeaveAllocation staffLeaveAllocation, DBConnection dBConnection);

        List<StaffLeaveAllocation> getStaffLeaveAllocationByEmpAndYear(int Emp, int Year, DBConnection dBConnection);

        List<StaffLeaveAllocation> getLeaveAllocation(int Year, int Type, int Emp, DBConnection dBConnection);
    }

    public class StaffLeaveAllocationDAOSqlImpl : StaffLeaveAllocationDAO
    {
        public List<StaffLeaveAllocation> getStaffLeaveAllocationByEmpAndYear(int Emp, int Year, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.Parameters.Clear();

            dBConnection.cmd.CommandText = "SELECT sla.Leave_Type_id,sla.Employee_ID,sla.Entitlement FROM Staff_Leave_Allocation sla WHERE sla.Leave_Year = @Year AND sla.Employee_ID = @Emp;";

            dBConnection.cmd.Parameters.AddWithValue("@Emp", Emp);
            dBConnection.cmd.Parameters.AddWithValue("@Year", Year);

            dBConnection.dr = dBConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<StaffLeaveAllocation>(dBConnection.dr);
        }

        public int saveStaffLeaveAllocation(StaffLeaveAllocation staffLeaveAllocation, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.CommandType = System.Data.CommandType.Text;
            dBConnection.cmd.Parameters.Clear();
            dBConnection.cmd.CommandText = "INSERT INTO Staff_Leave_Allocation (Employee_ID,Leave_Type_id,Leave_Year,No_Of_Days,Entitlement,Month_Limit,Month_Limit_Applied_To)" +
                " VALUES(@EMPID,@LeaveTypeId,@LYear,@NoOfDays,@Entitlement,@MonthLimit,@AppliedTo);";

            dBConnection.cmd.Parameters.AddWithValue("@EMPID", staffLeaveAllocation.EmployeesID);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveTypeId", staffLeaveAllocation.LeaveTypeId);
            dBConnection.cmd.Parameters.AddWithValue("@LYear", staffLeaveAllocation.LeaveYear);
            dBConnection.cmd.Parameters.AddWithValue("@NoOfDays", staffLeaveAllocation.NoOfDays);
            dBConnection.cmd.Parameters.AddWithValue("@Entitlement", staffLeaveAllocation.Entitlement);
            dBConnection.cmd.Parameters.AddWithValue("@MonthLimit", staffLeaveAllocation.MonthLimit);

            if (staffLeaveAllocation.MonthLimitAppliedTo.Year == 1)
            {
                dBConnection.cmd.Parameters.AddWithValue("@AppliedTo", SqlDateTime.Null);
            }
            else
            {
                dBConnection.cmd.Parameters.AddWithValue("@AppliedTo", staffLeaveAllocation.MonthLimitAppliedTo);
            }


            return dBConnection.cmd.ExecuteNonQuery();
        }

        public List<StaffLeaveAllocation> getLeaveAllocation(int Year, int Type, int Emp, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.Parameters.Clear();

            dBConnection.cmd.CommandText = "SELECT sla.Leave_Type_id,sla.Employee_ID,sla.Entitlement FROM Staff_Leave_Allocation sla WHERE sla.Leave_Year = @Year AND sla.Employee_ID = @Emp AND sla.Leave_Type_id = @Type;";

            dBConnection.cmd.Parameters.AddWithValue("@Emp", Emp);
            dBConnection.cmd.Parameters.AddWithValue("@Year", Year);
            dBConnection.cmd.Parameters.AddWithValue("@Type", Type);

            dBConnection.dr = dBConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<StaffLeaveAllocation>(dBConnection.dr);
        }

    }
}
