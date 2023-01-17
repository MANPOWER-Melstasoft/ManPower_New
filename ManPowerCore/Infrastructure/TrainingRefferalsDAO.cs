using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingRefferalsDAO
    {
        int Save(TrainingRefferals trainingRefferals, DBConnection dbConnection);
        int Update(TrainingRefferals trainingRefferals, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        List<TrainingRefferals> GetAllTrainingRefferals(bool with0, DBConnection dbConnection);
        TrainingRefferals GetTrainingRefferals(int id, DBConnection dbConnection);
    }

    public class TrainingRefferalsDAOSqlImmpl : TrainingRefferalsDAO
    {
        public int Save(TrainingRefferals trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO TrainingRefferals (Vote_Type_ID, Year_Allocation, Vote_Number, Amount, Reamin_Amount, Created_By, Created_Date) " +
                "VALUES (@Id, @BeneficiaryId, @Date, @InstituteName, @TrainingCourse, @ContactPerson, @ContactNo) ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRefferals.Id);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", trainingRefferals.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InstituteName", trainingRefferals.InstituteName);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCourse", trainingRefferals.TrainingCourse);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPerson", trainingRefferals.ContactPerson);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNo", trainingRefferals.ContactNo);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingRefferals trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE TrainingRefferals SET Date = @Date, BeneficiaryId = @BeneficiaryId, InstituteName = @InstituteName, " +
                "TrainingCourse = @TrainingCourse, ContactPerson = @ContactPerson, ContactNo = @ContactNo WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRefferals.Id);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", trainingRefferals.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InstituteName", trainingRefferals.InstituteName);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCourse", trainingRefferals.TrainingCourse);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPerson", trainingRefferals.ContactPerson);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNo", trainingRefferals.ContactNo);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE TrainingRefferals SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRefferals> GetAllTrainingRefferals(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferals";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferals WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRefferals>(dbConnection.dr);
        }

        public TrainingRefferals GetTrainingRefferals(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TrainingRefferals WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TrainingRefferals>(dbConnection.dr);
        }

    }
}
