using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
	public interface TransfersRetirementResignationMainDocumentController
	{
		int saveAll(int TransfersRetirementResignationMainId, string DocName);

		List<TransfersRetirementResignationMainDocuments> GetAllTransfersRetirementResignationMainDocument(bool with0);

		TransfersRetirementResignationMainDocuments GetTransfersRetirementResignationMainDocument();
	}

	public class TransfersRetirementResignationMainDocumentControllerImpl : TransfersRetirementResignationMainDocumentController
	{
		DBConnection dBConnection = null;
		TransfersRetirementResignationMainDocumentDAO transfersRetirementResignationMainDocumentDAO = DAOFactory.CreateTransfersRetirementResignationMainDocumentDAO();

		public int saveAll(int TransfersRetirementResignationMainId, string DocName)
		{
			try
			{
				dBConnection = new DBConnection();
				return transfersRetirementResignationMainDocumentDAO.saveAll(TransfersRetirementResignationMainId, DocName, dBConnection);
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

		public List<TransfersRetirementResignationMainDocuments> GetAllTransfersRetirementResignationMainDocument(bool with0)
		{
			try
			{
				dBConnection = new DBConnection();
				List<TransfersRetirementResignationMainDocuments> list = transfersRetirementResignationMainDocumentDAO.GetAllTransfersRetirementResignationMainDocument(with0, dBConnection);

				TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();

				foreach (var item in list)
				{
					item.transfersRetirementResignationMain = transfersRetirementResignationMainDAO.GetTransfersRetirementResignation(item.TransfersRetirementResignationMainId, dBConnection);
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

		public TransfersRetirementResignationMainDocuments GetTransfersRetirementResignationMainDocument()
		{
			try
			{
				dBConnection = new DBConnection();
				TransfersRetirementResignationMainDAO trrMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();

				TransfersRetirementResignationMainDocuments transfersRetirementResignationMainDocument = new TransfersRetirementResignationMainDocuments();
				transfersRetirementResignationMainDocument = transfersRetirementResignationMainDocumentDAO.GetTransfersRetirementResignationMainDocument(dBConnection);

				return transfersRetirementResignationMainDocument;
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
