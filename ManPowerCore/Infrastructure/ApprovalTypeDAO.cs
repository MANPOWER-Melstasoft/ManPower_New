using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ApprovalTypeDAO
    {
        int Save(ApprovalType approvalType, DBConnection dbConnection);

        int Update(ApprovalType approvalType, DBConnection dbConnection);

        List<ApprovalType> GetAllApprovalType(DBConnection dbConnection);
    }

    public class ApprovalTypeDAOImpl : ApprovalTypeDAO
    {
        public int Save(ApprovalType approvalType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Approval_Status (Status_Name) " +
                                    "VALUES (@StatusName)";

            dbConnection.cmd.Parameters.AddWithValue("@StatusName", approvalType.StatusName);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(ApprovalType approvalType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Approval_Status (Status_Name) " +
                                    "VALUES (@StatusName)";

            dbConnection.cmd.Parameters.AddWithValue("@StatusName", approvalType.StatusName);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<ApprovalType> GetAllApprovalType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Approval_Status";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ApprovalType>(dbConnection.dr);
        }
    }
}
