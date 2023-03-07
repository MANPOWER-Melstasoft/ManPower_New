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
    public interface ProgramPlanApprovalDetailsDAO
    {
        int Save(ProgramPlanApprovalDetails programPlanApprovalDetails, DBConnection dbConnection);

        List<ProgramPlanApprovalDetails> GetAll(DBConnection dbConnection);
    }
    public class ProgramPlanApprovalDetailsDAOImpl : ProgramPlanApprovalDetailsDAO
    {
        public int Save(ProgramPlanApprovalDetails programPlanApprovalDetails, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Program_Plan_Approval_Details(ProgramPlan_Id,ProgramPlan_Status,Recommendation1_By,Recommendation1_Date,Recommendation2_By,Recommendation2_Date,Reject_Reason) " +
                "VALUES(@ProgramPlanId,@ProjectStatus,@Recommendation1By,@Recommendation1Date,@Recommendation2By,@Recommendation2Date,@RejectReason)";


            dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programPlanApprovalDetails.ProgramPlanId);
            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatus", programPlanApprovalDetails.ProjectStatus);
            dbConnection.cmd.Parameters.AddWithValue("@Recommendation1By", programPlanApprovalDetails.Recommendation1By);
            if (programPlanApprovalDetails.Recommendation1Date.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@Recommendation1Date", SqlDateTime.Null);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@Recommendation1Date", programPlanApprovalDetails.Recommendation1Date);

            }
            dbConnection.cmd.Parameters.AddWithValue("@Recommendation2By", programPlanApprovalDetails.Recommendation2By);

            if (programPlanApprovalDetails.Recommendation2Date.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@Recommendation2Date", SqlDateTime.Null);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@Recommendation2Date", programPlanApprovalDetails.Recommendation2Date);

            }
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", programPlanApprovalDetails.RejectReason);



            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
            return output;
        }

        public List<ProgramPlanApprovalDetails> GetAll(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Program_Plan_Approval_Details";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlanApprovalDetails>(dbConnection.dr);
        }
    }
}
