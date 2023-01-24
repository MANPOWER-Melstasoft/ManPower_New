using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface CareerGuidanceFeedbackDAO
    {
        int Save(CareerGuidanceFeedback careerGuidanceFeedback, DBConnection dbConnection);
        int Update(CareerGuidanceFeedback careerGuidanceFeedback, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        List<CareerGuidanceFeedback> GetAllCareerGuidanceFeedback(bool with0, DBConnection dbConnection);
        CareerGuidanceFeedback GetCareerGuidanceFeedback(int id, DBConnection dbConnection);
    }

    public class CareerGuidanceFeedbackDAOSqlImpl : CareerGuidanceFeedbackDAO
    {

        public int Save(CareerGuidanceFeedback careerGuidanceFeedback, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO Career_Guidance_Feedback (Career_Key_Test_Results_Id, Created_Date, In_Job, In_Training, Other_Remarks, Created_User) " +
                "VALUES (@CareerKeyTestResultsId, @Date, @InJob, @InTraining, @Remarks, @Created_User) SELECT SCOPE_IDENTITY()";

            dbConnection.cmd.Parameters.AddWithValue("@CareerKeyTestResultsId", careerGuidanceFeedback.CareerKeyTestResultsId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", careerGuidanceFeedback.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InJob", careerGuidanceFeedback.InJob);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", careerGuidanceFeedback.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", careerGuidanceFeedback.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@Created_User", careerGuidanceFeedback.Remarks);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(CareerGuidanceFeedback careerGuidanceFeedback, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            //dbConnection.cmd.CommandText = "UPDATE Career_Guidance_Feedback SET Created_Date = @Date, Career_Key_Test_Results_Id = @CareerKeyTestResultsId, In_Job = @InJob, " +
            //    "In_Training = @InTraining, Other_Remarks = @Remarks, Created_User = @Created_User WHERE Id = @Id";

            dbConnection.cmd.CommandText = "UPDATE Career_Guidance_Feedback SET Created_Date = @Date, In_Job = @InJob WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", careerGuidanceFeedback.Id);
            //   dbConnection.cmd.Parameters.AddWithValue("@CareerKeyTestResultsId", careerGuidanceFeedback.CareerKeyTestResultsId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", careerGuidanceFeedback.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InJob", careerGuidanceFeedback.InJob);
            //   dbConnection.cmd.Parameters.AddWithValue("@InTraining", careerGuidanceFeedback.InTraining);
            //  dbConnection.cmd.Parameters.AddWithValue("@Remarks", careerGuidanceFeedback.Remarks);
            //  dbConnection.cmd.Parameters.AddWithValue("@Created_User", careerGuidanceFeedback.Remarks);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Career_Guidance_Feedback SET Is_Active = 0 WHERE Id = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<CareerGuidanceFeedback> GetAllCareerGuidanceFeedback(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Career_Guidance_Feedback";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Career_Guidance_Feedback WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CareerGuidanceFeedback>(dbConnection.dr);
        }

        public CareerGuidanceFeedback GetCareerGuidanceFeedback(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Career_Guidance_Feedback WHERE Id = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CareerGuidanceFeedback>(dbConnection.dr);
        }

    }

}
