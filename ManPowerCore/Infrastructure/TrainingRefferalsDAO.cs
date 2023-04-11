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
        List<TrainingRefferals> GetAllTrainingRefferalsByBene(int BeneId, DBConnection dbConnection);
    }

    public class TrainingRefferalsDAOSqlImmpl : TrainingRefferalsDAO
    {
        public int Save(TrainingRefferals trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();

            if (trainingRefferals.Program_Plan_Id == 0)
            {
                dbConnection.cmd.CommandText = "INSERT INTO Training_Refferals (Beneficiary_Id, Created_Date, Institute_Name, Training_Course, Contact_Person_Name, Contact_No, Refferals_Date, Created_User) " +
             "VALUES (@BeneficiaryId, @Date, @InstituteName, @TrainingCourse, @ContactPerson, @ContactNo, @Refferals_Date, @Created_User) SELECT SCOPE_IDENTITY()";
            }
            else
            {
                dbConnection.cmd.CommandText = "INSERT INTO Training_Refferals (Beneficiary_Id, Created_Date, Institute_Name, Training_Course, Contact_Person_Name, Contact_No, Refferals_Date, Created_User, Program_Plan_Id) " +
             "VALUES (@BeneficiaryId, @Date, @InstituteName, @TrainingCourse, @ContactPerson, @ContactNo, @Refferals_Date, @Created_User,@Program_Plan_Id) SELECT SCOPE_IDENTITY()";
            }


            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", trainingRefferals.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InstituteName", trainingRefferals.InstituteName);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCourse", trainingRefferals.TrainingCourse);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPerson", trainingRefferals.ContactPerson);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNo", trainingRefferals.ContactNo);
            dbConnection.cmd.Parameters.AddWithValue("@Refferals_Date", trainingRefferals.RefferalsDate);
            dbConnection.cmd.Parameters.AddWithValue("@Created_User", trainingRefferals.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@Program_Plan_Id", trainingRefferals.Program_Plan_Id);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingRefferals trainingRefferals, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Training_Refferals SET Created_Date = @Date, Beneficiary_Id = @BeneficiaryId, Institute_Name = @InstituteName, " +
                "Training_Course = @TrainingCourse, Contact_Person_Name = @ContactPerson, Contact_No = @ContactNo, Refferals_Date = @Refferals_Date, Created_User = @Created_User WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRefferals.Id);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", trainingRefferals.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", trainingRefferals.Date);
            dbConnection.cmd.Parameters.AddWithValue("@InstituteName", trainingRefferals.InstituteName);
            dbConnection.cmd.Parameters.AddWithValue("@TrainingCourse", trainingRefferals.TrainingCourse);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPerson", trainingRefferals.ContactPerson);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNo", trainingRefferals.ContactNo);
            dbConnection.cmd.Parameters.AddWithValue("@Refferals_Date", trainingRefferals.RefferalsDate);
            dbConnection.cmd.Parameters.AddWithValue("@Created_User", trainingRefferals.CreatedUser);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Training_Refferals SET Is_Active = 0 WHERE Id = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRefferals> GetAllTrainingRefferals(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferals";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferals WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRefferals>(dbConnection.dr);
        }

        public TrainingRefferals GetTrainingRefferals(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferals WHERE Id = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TrainingRefferals>(dbConnection.dr);
        }

        public List<TrainingRefferals> GetAllTrainingRefferalsByBene(int BeneId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();


            dbConnection.cmd.CommandText = "SELECT * FROM Training_Refferals WHERE Beneficiary_Id = " + BeneId + " AND Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRefferals>(dbConnection.dr);
        }
    }
}
