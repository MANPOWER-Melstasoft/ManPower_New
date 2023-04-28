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
	public interface TransfersRetirementResignationMainDocumentController
	{
		int saveAll(int TransfersRetirementResignationMainId, string DocName);
	}

	public class TransfersRetirementResignationMainDocumentControllerImpl : TransfersRetirementResignationMainDocumentController
	{
		DBConnection dbConnection = null;
		TransfersRetirementResignationMainDocumentDAO transfersRetirementResignationMainDocumentDAO = DAOFactory.CreateTransfersRetirementResignationMainDocumentDAO();

		public int saveAll(int TransfersRetirementResignationMainId, string DocName)
		{
			try
			{
				dbConnection = new DBConnection();
				return transfersRetirementResignationMainDocumentDAO.saveAll(TransfersRetirementResignationMainId, DocName, dbConnection);
			}
			catch (Exception)
			{
				dbConnection.RollBack();
				throw;
			}
			finally
			{
				if (dbConnection.con.State == System.Data.ConnectionState.Open)
					dbConnection.Commit();
			}
		}
	}
}
