using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ApprovalHistoryDAO
    {
        int Save(ApprovalHistory approvalHistory, DBConnection dbConnection);

        int Update(ApprovalHistory approvalHistory, DBConnection dbConnection);

        List<ApprovalHistory> GetAllApprovalHistory(DBConnection dbConnection);
    }

    public class ApprovalHistoryDAOSqlImpl : ApprovalHistoryDAO
    {
        public int Save(ApprovalHistory approvalHistory, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Approval_History (Loan_Details_Id, Approval_Status_Id, Approve_By, Approve_Date, Reject_Reason) " +
                                "VALUES (@LoanDetailsId, @ApprovalStatusId, @ApproveBy, @ApproveDate, @RejectReason)";

            dbConnection.cmd.Parameters.AddWithValue("@LoanDetailsId", approvalHistory.LoanDetailsId);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalStatusId", approvalHistory.ApprovalStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ApproveBy", approvalHistory.ApproveBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApproveDate", approvalHistory.ApproveDate);
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", approvalHistory.RejectReason);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(ApprovalHistory approvalHistory, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Approval_History " +
                                "SET Loan_Details_Id = @LoanDetailsId, Approval_Status_Id = @ApprovalStatusId, Approve_By = @ApproveBy, Approve_Date = @ApproveDate, Reject_Reason = @RejectReason " +
                                "WHERE Id = @ApprovalHistoryId";

            dbConnection.cmd.Parameters.AddWithValue("@LoanDetailsId", approvalHistory.LoanDetailsId);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalStatusId", approvalHistory.ApprovalStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ApproveBy", approvalHistory.ApproveBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApproveDate", approvalHistory.ApproveDate);
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", approvalHistory.RejectReason);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalHistoryId", approvalHistory.ApprovalHistoryId);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<ApprovalHistory> GetAllApprovalHistory(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Approval_History";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ApprovalHistory>(dbConnection.dr);
        }
    }
}
