using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{

    public interface TrainingRequestsDAO
    {
        int Save(TrainingRequests trainingRequests, DBConnection dbConnection);

        int Update(TrainingRequests trainingRequests, DBConnection dbConnection);

        List<TrainingRequests> GetAllTrainingRequests(DBConnection dbConnection);
    }

    public class TrainingRequestsDAOSqlImpl : TrainingRequestsDAO
    {
        public int Save(TrainingRequests trainingRequests, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Training_Requests (Training_main_id, Project_status_id, Created_date, Created_user,Accepted_date, Accepted_user) " +
                "VALUES (@TrainingMainId, @ProjectStatusId, @CreatedDate, @CreatedUser, @AcceptedDate, @AcceptedUser) ";

            dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", trainingRequests.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingRequests.Created_Date);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingRequests.Created_User);
            dbConnection.cmd.Parameters.AddWithValue("@AcceptedDate", trainingRequests.Accepted_Date);
            dbConnection.cmd.Parameters.AddWithValue("@AcceptedUser", trainingRequests.Accepted_User);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingRequests trainingRequests, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Training_Requests SET Training_main_id = @TrainingMainId, Project_status_id = @ProjectStatusId, Created_date = @CreatedDate, Created_user = @CreatedUser, " +
                                "Accepted_date = @AcceptedDate, Accepted_user = @AcceptedUser, Is_Active = @IsActive WHERE Id = @Id) ";

            dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", trainingRequests.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingRequests.Created_Date);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingRequests.Created_User);
            dbConnection.cmd.Parameters.AddWithValue("@AcceptedDate", trainingRequests.Accepted_Date);
            dbConnection.cmd.Parameters.AddWithValue("@AcceptedUser", trainingRequests.Accepted_User);
            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRequests.TrainingRequestsId);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", trainingRequests.Is_Active);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRequests> GetAllTrainingRequests(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Requests";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRequests>(dbConnection.dr);
        }
    }

}
