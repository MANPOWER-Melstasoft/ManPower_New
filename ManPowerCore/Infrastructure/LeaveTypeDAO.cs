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
    public interface LeaveTypeDAO
    {
        List<LeaveType> GetAllLeaveTypes(DBConnection dbConnection);
        LeaveType GetLeaveTypeById(int id, DBConnection dbConnection);
    }
    public class LeaveTypeDAOSqlImpl : LeaveTypeDAO
    {
        public List<LeaveType> GetAllLeaveTypes(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Leave_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<LeaveType>(dbConnection.dr);
        }
        public LeaveType GetLeaveTypeById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Leave_Type WHERE ID=" + id + " ";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<LeaveType>(dbConnection.dr);
        }
    }
}
