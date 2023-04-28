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
	public interface ResignationController
	{
		int Save(TransfersRetirementResignationMain transfersRetirementResignationMain, Resignation resignation, List<string> DocList);
		int Delete(int id);
		int Update(Resignation resignation);
		List<Resignation> GetAllResignation(bool with0);
		Resignation GetResignationByMainId(int Id);
	}

	public class ResignationControllerSqlImpl : ResignationController
	{
		ResignationDAO resignationDAO = DAOFactory.CreateResignationDAO();
		DBConnection dBConnection;

		public int Save(TransfersRetirementResignationMain transfersRetirementResignationMain, Resignation resignation, List<string> DocList)
		{
			try
			{
				int output = 0;
				dBConnection = new DBConnection();
				TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();
				resignation.MainId = transfersRetirementResignationMainDAO.Save(transfersRetirementResignationMain, dBConnection);

				output = resignationDAO.Save(resignation, dBConnection);
				if (output != 0 && DocList.Count > 0)
				{
					TransfersRetirementResignationMainDocumentDAO transfersRetirementResignationMainDocumentDAO = DAOFactory.CreateTransfersRetirementResignationMainDocumentDAO();
					foreach (string doc in DocList)
					{
						transfersRetirementResignationMainDocumentDAO.saveAll(resignation.MainId, doc, dBConnection);
					}
				}
				return output;
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

		public int Update(Resignation resignation)
		{
			try
			{
				dBConnection = new DBConnection();
				return resignationDAO.Update(resignation, dBConnection);
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

		public int Delete(int id)
		{
			try
			{
				dBConnection = new DBConnection();
				return resignationDAO.Delete(id, dBConnection);
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

		public List<Resignation> GetAllResignation(bool with0)
		{
			try
			{
				dBConnection = new DBConnection();
				return resignationDAO.GetAllResignation(with0, dBConnection);
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

		public Resignation GetResignationByMainId(int Id)
		{
			try
			{
				dBConnection = new DBConnection();
				return resignationDAO.GetResignationByMainId(Id, dBConnection);
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

	}
}
