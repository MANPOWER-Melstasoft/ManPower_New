using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
	public interface ApprovedTrainingRequestDocumentsController
	{
		int saveAll(int ApprovedTrainingRequestId, string Docs);

		List<ApprovedTrainingRequestDocuments> GetAllApprovedTrainingRequestDocuments(bool with0);

		ApprovedTrainingRequestDocuments GetApprovedTrainingRequestDocuments();

	}
	public class ApprovedTrainingRequestDocumentsControllerImpl : ApprovedTrainingRequestDocumentsController
	{
		DBConnection dBConnection = null;
		ApprovedTrainingRequestDocumentsDAO approvedTrainingRequestDocumentsDAO = DAOFactory.CreateApprovedTrainingRequestDocumentsDAO();

		public int saveAll(int ApprovedTrainingRequestId, string Docs)
		{
			try
			{
				dBConnection = new DBConnection();
				return approvedTrainingRequestDocumentsDAO.saveAll(ApprovedTrainingRequestId, Docs, dBConnection);
			}
			catch (Exception)
			{
				dBConnection.RollBack();
				throw;
			}
			finally
			{
				if (dBConnection.con.State == System.Data.ConnectionState.Open)
					dBConnection.Commit();
			}
		}

		public List<ApprovedTrainingRequestDocuments> GetAllApprovedTrainingRequestDocuments(bool with0)
		{
			try
			{
				dBConnection = new DBConnection();
				List<ApprovedTrainingRequestDocuments> list = approvedTrainingRequestDocumentsDAO.GetAllApprovedTrainingRequestDocuments(with0, dBConnection);

				TrainingRequestsDAO trainingRequestsDAO = DAOFactory.createTrainingRequestsDAO();

				foreach (var item in list)
				{
					item.trainingRequests = trainingRequestsDAO.GetTrainingRequests(item.ApprovedTrainingRequestId, dBConnection);
				}

				return list;
			}
			catch (Exception)
			{
				dBConnection.RollBack();
				throw;
			}
			finally
			{
				if (dBConnection.con.State == System.Data.ConnectionState.Open)
					dBConnection.Commit();
			}
		}

		public ApprovedTrainingRequestDocuments GetApprovedTrainingRequestDocuments()
		{
			try
			{
				dBConnection = new DBConnection();
				TrainingRequestsDAO trDAO = DAOFactory.createTrainingRequestsDAO();

				ApprovedTrainingRequestDocuments approvedTrainingRequestDocuments = new ApprovedTrainingRequestDocuments();
				approvedTrainingRequestDocuments = approvedTrainingRequestDocumentsDAO.GetApprovedTrainingRequestDocuments(dBConnection);

				return approvedTrainingRequestDocuments;
			}
			catch (Exception ex)
			{
				dBConnection.RollBack();
				throw;
			}
			finally
			{
				if (dBConnection.con.State == System.Data.ConnectionState.Open)
					dBConnection.Commit();
			}
		}
	}
}
