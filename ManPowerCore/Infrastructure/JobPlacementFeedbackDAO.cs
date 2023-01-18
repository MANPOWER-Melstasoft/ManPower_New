using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface JobPlacementFeedbackDAO
    {
        int SaveJobPlacementFeedback(JobPlacementFeedback jobPlacementFeedback, DBConnection dbConnection);

        List<JobPlacementFeedback> GetAllJobPlacementFeedback(DBConnection dbConnection);
    }

    public class JobPlacementFeedbackDAOImpl : JobPlacementFeedbackDAO
    {
        public int SaveJobPlacementFeedback(JobPlacementFeedback jobPlacementFeedback, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(Job_Refferals_Id,Created_Date,Created_User,Still_Working, " +
                                            "Resigned_Date,Remarks,Is_Active) " +
                                           "VALUES(@JobRefferalsId,@CreatedDate,@CreatedUser,@StillWorking,@ResignedDate,@Remarks, " +
                                           "@IsActive) ";


            dbConnection.cmd.Parameters.AddWithValue("@JobRefferalsId", jobPlacementFeedback.JobRefferalsId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", jobPlacementFeedback.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", jobPlacementFeedback.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StillWorking", jobPlacementFeedback.StillWorking);
            dbConnection.cmd.Parameters.AddWithValue("@ResignedDate", jobPlacementFeedback.ResignedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", jobPlacementFeedback.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", jobPlacementFeedback.IsActive);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<JobPlacementFeedback> GetAllJobPlacementFeedback(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM JOB_PLACEMENT_FEEDBACK";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<JobPlacementFeedback>(dbConnection.dr);

        }
    }
}
