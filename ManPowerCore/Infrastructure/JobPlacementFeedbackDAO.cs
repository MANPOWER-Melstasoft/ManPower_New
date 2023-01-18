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
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(Company_Vacancy_Resgistration_Id,Beneficiary_Id,Job_Category_Id,Created_Date, " +
                                            "Remarks,Job_Placement_Date,Career_Guidance,Is_Active) " +
                                           "VALUES(@VacancyRegistrationId,@BeneficiaryId,@JobCategoryId,@AssignedDate,@RefferalRemarks,@JobPlacementDate, " +
                                           "@CareerGuidance,@IsActive) ";


            dbConnection.cmd.Parameters.AddWithValue("@VacancyRegistrationId", jobRefferals.VacancyRegistrationId);

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
