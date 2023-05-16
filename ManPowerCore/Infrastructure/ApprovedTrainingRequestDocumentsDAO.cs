using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
	public interface ApprovedTrainingRequestDocumentsDAO
	{
		int saveAll(int TransfersRetirementResignationMainId, string DocName, DBConnection dbConnection);

		List<ApprovedTrainingRequestDocuments> GetAllApprovedTrainingRequestDocuments(bool with0, DBConnection dbConnection);

		ApprovedTrainingRequestDocuments GetApprovedTrainingRequestDocuments(DBConnection dbConnection);
	}
	public class ApprovedTrainingRequestDocumentsDAOSqlImpl : ApprovedTrainingRequestDocumentsDAO
	{
		public int saveAll(int ApprovedTrainingRequestId, string Docs, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "INSERT INTO Approved_Training_Request_Documents(Approved_Training_Request_Id,Documents) " +
											"Values(@Approved_Training_Request_Id, @Documents)";


			dbConnection.cmd.Parameters.AddWithValue("@Approved_Training_Request_Id", ApprovedTrainingRequestId);
			dbConnection.cmd.Parameters.AddWithValue("@Documents", Docs);


			dbConnection.cmd.ExecuteNonQuery();

			return 1;
		}

		public List<ApprovedTrainingRequestDocuments> GetAllApprovedTrainingRequestDocuments(bool with0, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			if (with0)
				dbConnection.cmd.CommandText = "SELECT * FROM Approved_Training_Request_Documents";
			else
				dbConnection.cmd.CommandText = "SELECT * FROM Approved_Training_Request_Documents WHERE Is_Active = 1";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<ApprovedTrainingRequestDocuments>(dbConnection.dr);
		}

		public ApprovedTrainingRequestDocuments GetApprovedTrainingRequestDocuments(DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "SELECT * FROM Approved_Training_Request_Documents";



			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.GetSingleOject<ApprovedTrainingRequestDocuments>(dbConnection.dr);
		}
	}
}
