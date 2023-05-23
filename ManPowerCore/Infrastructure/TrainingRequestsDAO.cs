using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{

	public interface TrainingRequestsDAO
	{
		int Save(TrainingRequests trainingRequests, DBConnection dbConnection);

		int Update(TrainingRequests trainingRequests, DBConnection dbConnection);
		int Delete(TrainingRequests trainingRequests, DBConnection dbConnection);

		int UpdateRec(TrainingRequests trainingRequests, DBConnection dbConnection);

		List<TrainingRequests> GetAllTrainingRequestsBiMainId(int id, DBConnection dbConnection);
		List<TrainingRequests> GetAllTrainingRequests(DBConnection dbConnection);

		TrainingRequests GetTrainingRequests(int Id, DBConnection dbConnection);

		int updateTraining(TrainingRequests trainingRequests, DBConnection dbConnection);
	}

	public class TrainingRequestsDAOSqlImpl : TrainingRequestsDAO
	{
		public int Save(TrainingRequests trainingRequests, DBConnection dbConnection)
		{
			int output = 0;

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.CommandText = "INSERT INTO Training_Requests (Training_main_id, Project_status_id, Created_date, Created_user) " +
				"VALUES (@TrainingMainId, @ProjectStatusId, @CreatedDate, @CreatedUser) SELECT SCOPE_IDENTITY()";

			dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
			dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", trainingRequests.ProjectStatusId);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingRequests.Created_Date);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingRequests.Created_User);


			output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

			return output;
		}

		public int Update(TrainingRequests trainingRequests, DBConnection dbConnection)
		{
			int output = 0;

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.CommandText = "UPDATE Training_Requests SET Training_main_id = @TrainingMainId, Project_status_id = @ProjectStatusId, Created_date = @CreatedDate, Created_user = @CreatedUser, " +
								"Accepted_date = @AcceptedDate, Accepted_user = @AcceptedUser, Is_Active = @IsActive WHERE Id = @Id";

			dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
			dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", trainingRequests.ProjectStatusId);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingRequests.Created_Date);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingRequests.Created_User);
			dbConnection.cmd.Parameters.AddWithValue("@AcceptedDate", trainingRequests.Accepted_Date);
			dbConnection.cmd.Parameters.AddWithValue("@AcceptedUser", trainingRequests.Accepted_User);
			dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRequests.TrainingRequestsId);
			dbConnection.cmd.Parameters.AddWithValue("@IsActive", trainingRequests.Is_Active);

			output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

			return output;
		}

		public int UpdateRec(TrainingRequests trainingRequests, DBConnection dbConnection)
		{
			int output = 0;

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.CommandText = "UPDATE Training_Requests SET Training_main_id = @TrainingMainId, Project_status_id = @ProjectStatusId, Created_date = @CreatedDate, Created_user = @CreatedUser, " +
								"Recommend_date = @Recommend_date, Recommend_user = @Recommend_user, Is_Active = @IsActive WHERE Id = @Id";

			dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
			dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", trainingRequests.ProjectStatusId);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingRequests.Created_Date);
			dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingRequests.Created_User);
			dbConnection.cmd.Parameters.AddWithValue("@Recommend_date", trainingRequests.Recommend_date);
			dbConnection.cmd.Parameters.AddWithValue("@Recommend_user", trainingRequests.Recommend_user);
			dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRequests.TrainingRequestsId);
			dbConnection.cmd.Parameters.AddWithValue("@IsActive", trainingRequests.Is_Active);

			output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

			return output;
		}

		public int Delete(TrainingRequests trainingRequests, DBConnection dbConnection)
		{
			int output = 0;

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.CommandText = "DELETE FROM Training_Requests WHERE Id = @Id";

			dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRequests.TrainingRequestsId);

			output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

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


		public List<TrainingRequests> GetAllTrainingRequestsBiMainId(int id, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandText = "SELECT * FROM Training_Requests WHERE Training_main_id = " + id + ";";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<TrainingRequests>(dbConnection.dr);
		}

		public TrainingRequests GetTrainingRequests(int Id, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "SELECT * FROM Training_Requests WHERE Id = @Id";

			dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.GetSingleOject<TrainingRequests>(dbConnection.dr);
		}

		public int updateTraining(TrainingRequests trainingRequests, DBConnection dbConnection)
		{
			int output = 0;

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.CommandText = "UPDATE Training_Requests SET Training_main_id = @TrainingMainId WHERE Id = @Id";

			dbConnection.cmd.Parameters.AddWithValue("@TrainingMainId", trainingRequests.TrainingMainId);
			dbConnection.cmd.Parameters.AddWithValue("@Id", trainingRequests.TrainingRequestsId);


			output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

			return output;
		}
	}

}
