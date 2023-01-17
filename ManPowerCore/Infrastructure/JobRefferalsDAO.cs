using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface JobRefferalsDAO
    {
        int SaveJobRefferals(JobRefferals jobRefferals, DBConnection dbConnection);

        List<JobRefferals> GetAllJobRefferals(DBConnection dbConnection);
    }

    public class JobRefferalsDAOImpl : JobRefferalsDAO
    {
        public int SaveJobRefferals(JobRefferals jobRefferals, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(Company_Vacancy_Resgistration_Id,Beneficiary_Id,Job_Category_Id,Created_Date, " +
                                            "Remarks,Job_Placement_Date,Career_Guidance,Is_Active) " +
                                           "VALUES(@VacancyRegistrationId,@BeneficiaryId,@JobCategoryId,@AssignedDate,@RefferalRemarks,@JobPlacementDate, " +
                                           "@CareerGuidance,@IsActive) ";


            dbConnection.cmd.Parameters.AddWithValue("@VacancyRegistrationId", jobRefferals.VacancyRegistrationId);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", jobRefferals.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@JobCategoryId", jobRefferals.JobCategoryId);
            dbConnection.cmd.Parameters.AddWithValue("@AssignedDate", jobRefferals.AssignedDate);
            dbConnection.cmd.Parameters.AddWithValue("@RefferalRemarks", jobRefferals.RefferalRemarks);
            dbConnection.cmd.Parameters.AddWithValue("@JobPlacementDate", jobRefferals.JobPlacementDate);
            dbConnection.cmd.Parameters.AddWithValue("@CareerGuidance", jobRefferals.CareerGuidance);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", jobRefferals.IsActive);


            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<JobRefferals> GetAllJobRefferals(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM JOB_REFFERALS";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<JobRefferals>(dbConnection.dr);

        }
    }
}
