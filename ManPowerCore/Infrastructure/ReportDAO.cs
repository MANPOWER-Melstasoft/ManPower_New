using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ReportDAO
    {
        DataTable GetLeaveBalance(DBConnection dBConnection);
    }
    public class ReportDAOSqlImpl : ReportDAO
    {
        public DataTable GetLeaveBalance(DBConnection dBConnection)
        {
            DataTable tableLeaveBalance = new DataTable();

            dBConnection.cmd.CommandText = "SELECT Staff_Leave_Allocation.Leave_Type_id,Staff_Leave_Allocation.Employee_ID,Staff_Leave_Allocation.Entitlement,Staff_Leave.No_Of_Leave,Staff_Leave.Approved_By FROM Staff_Leave_Allocation INNER JOIN Staff_Leave ON Staff_Leave.Employee_ID = Staff_Leave_Allocation.Employee_ID AND Staff_Leave.Leave_Type_id = Staff_Leave_Allocation.Leave_Type_id";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(dBConnection.cmd);
            dataAdapter.Fill(tableLeaveBalance);

            return tableLeaveBalance;
        }
    }
}
