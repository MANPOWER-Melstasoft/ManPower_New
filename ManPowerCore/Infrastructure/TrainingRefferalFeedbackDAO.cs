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
            dbConnection.cmd.CommandText = "INSERT INTO Training_Refferal_Feedback (Training_Refferals_Id, Created_Date, Training_Institute, In_Training, Training_Completed, Other_Remarks, Created_User) " +
                "VALUES (@TrainingRefferalId, @Date, @TrainingInstitute, @InTraining, @TrainingCompleted, @Remarks, @Created_User) SELECT SCOPE_IDENTITY()";

            dbConnection.cmd.Parameters.AddWithValue("@TrainingRefferalId", trainingRefferals.TrainingRefferalId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingInstitute", trainingRefferals.TrainingInstitute);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", trainingRefferals.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCompleted", trainingRefferals.TrainingCompleted);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", trainingRefferals.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@Created_User", trainingRefferals.CreatedUser);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingRefferalFeedback trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Training_Refferal_Feedback SET Created_Date = @Date, Training_Institute = @TrainingInstitute, " +
                "In_Training = @InTraining, Training_Completed = @TrainingCompleted, Other_Remarks = @Remarks, Created_User = @Created_User WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRefferals.Id);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingInstitute", trainingRefferals.TrainingInstitute);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", trainingRefferals.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCompleted", trainingRefferals.TrainingCompleted);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", trainingRefferals.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@Created_User", trainingRefferals.CreatedUser);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Training_Refferal_Feedback SET Is_Active = 0 WHERE Id = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRefferalFeedback> GetAllTrainingRefferalFeedback(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferal_Feedback";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferal_Feedback WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRefferalFeedback>(dbConnection.dr);
        }

        public TrainingRefferalFeedback GetTrainingRefferalFeedback(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferal_Feedback WHERE Id = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TrainingRefferalFeedback>(dbConnection.dr);
        }
    }
}
