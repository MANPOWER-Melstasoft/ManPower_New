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
            dbConnection.cmd.CommandText = "INSERT INTO CareerGuidanceFeedback (Vote_Type_ID, Year_Allocation, Vote_Number, Amount, Reamin_Amount, Created_By, Created_Date) " +
                "VALUES (@Id, @CareerKeyTestResultsId, @Date, @InJob, @InTraining, @Remarks) ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", careerGuidanceFeedback.Id);
            dbConnection.cmd.Parameters.AddWithValue("@CareerKeyTestResultsId", careerGuidanceFeedback.CareerKeyTestResultsId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", careerGuidanceFeedback.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InJob", careerGuidanceFeedback.InJob);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", careerGuidanceFeedback.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", careerGuidanceFeedback.Remarks);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(CareerGuidanceFeedback careerGuidanceFeedback, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE CareerGuidanceFeedback SET Date = @Date, CareerKeyTestResultsId = @CareerKeyTestResultsId, InJob = @InJob, " +
                "InTraining = @InTraining, Remarks = @Remarks WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", careerGuidanceFeedback.Id);
            dbConnection.cmd.Parameters.AddWithValue("@CareerKeyTestResultsId", careerGuidanceFeedback.CareerKeyTestResultsId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", careerGuidanceFeedback.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InJob", careerGuidanceFeedback.InJob);
            dbConnection.cmd.Parameters.AddWithValue("@InTraining", careerGuidanceFeedback.InTraining);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", careerGuidanceFeedback.Remarks);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE CareerGuidanceFeedback SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<CareerGuidanceFeedback> GetAllCareerGuidanceFeedback(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM CareerGuidanceFeedback";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM CareerGuidanceFeedback WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CareerGuidanceFeedback>(dbConnection.dr);
        }

        public CareerGuidanceFeedback GetCareerGuidanceFeedback(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CareerGuidanceFeedback WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CareerGuidanceFeedback>(dbConnection.dr);
        }

    }

}
