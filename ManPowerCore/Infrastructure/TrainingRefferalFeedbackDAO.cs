using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingRefferalFeedbackDAO
    {
        int Save(TrainingRefferalFeedback trainingRefferals, DBConnection dbConnection);
        int Update(TrainingRefferalFeedback trainingRefferals, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        List<TrainingRefferalFeedback> GetAllTrainingRefferalFeedback(bool with0, DBConnection dbConnection);
        TrainingRefferalFeedback GetTrainingRefferalFeedback(int id, DBConnection dbConnection);
    }

    public class TrainingRefferalFeedbackDAOSqlImpl : TrainingRefferalFeedbackDAO
    {
        public int Save(TrainingRefferalFeedback trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO TrainingRefferalFeedback (Vote_Type_ID, Year_Allocation, Vote_Number, Amount, Reamin_Amount, Created_By, Created_Date) " +
                "VALUES (@TrainingRefferalId, @Date, @TrainingInstitute, @InTraining, @TrainingCompleted, @Remarks) ";

            dbConnection.cmd.Parameters.AddWithValue("@TrainingRefferalId", trainingRefferals.TrainingRefferalId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingInstitute", trainingRefferals.TrainingInstitute);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", trainingRefferals.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCompleted", trainingRefferals.TrainingCompleted);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", trainingRefferals.Remarks);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingRefferalFeedback trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE TrainingRefferalFeedback SET Date = @Date, TrainingRefferalId = @TrainingRefferalId, TrainingInstitute = @TrainingInstitute, " +
                "InTraining = @InTraining, TrainingCompleted = @TrainingCompleted, Remarks = @Remarks WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRefferals.Id);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingRefferalId", trainingRefferals.TrainingRefferalId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingInstitute", trainingRefferals.TrainingInstitute);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", trainingRefferals.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCompleted", trainingRefferals.TrainingCompleted);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", trainingRefferals.Remarks);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE TrainingRefferalFeedback SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRefferalFeedback> GetAllTrainingRefferalFeedback(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferals";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferalFeedback WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRefferalFeedback>(dbConnection.dr);
        }

        public TrainingRefferalFeedback GetTrainingRefferalFeedback(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferalFeedback WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TrainingRefferalFeedback>(dbConnection.dr);
        }
    }
}
