﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
	public interface TrainingMainController
	{
		int Save(TrainingMain trainingMain);

		int Update(TrainingMain trainingMain);

		List<TrainingMain> GetAllTrainingMain();

		TrainingMain GetTrainingMainById(int id);
	}

	public class TrainingMainControllerImpl : TrainingMainController
	{
		DBConnection dBConnection;
		TrainingMainDAO trainingMainDAO = DAOFactory.CreateTrainingMainDAO();
		public int Save(TrainingMain trainingMain)
		{
			try
			{
				dBConnection = new DBConnection();
				return trainingMainDAO.Save(trainingMain, dBConnection);
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

		public int Update(TrainingMain trainingMain)
		{
			try
			{
				dBConnection = new DBConnection();
				return trainingMainDAO.Update(trainingMain, dBConnection);
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

		public List<TrainingMain> GetAllTrainingMain()
		{
			try
			{
				dBConnection = new DBConnection();
				List<TrainingMain> trainingMains = trainingMainDAO.GetAllTrainingMain(dBConnection);
				DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
				SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();

				foreach (TrainingMain trainingMain in trainingMains)
				{
					DepartmentUnitPositions departmentUnitPositions = departmentUnitPositionsDAO.GetDepartmentUnitPositions(trainingMain.Created_User, dBConnection);

					trainingMain.createdUser = systemUserDAO.GetSystemUser(departmentUnitPositions.SystemUserId, dBConnection);
				}

				return trainingMains;
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

		public TrainingMain GetTrainingMainById(int id)
		{
			DBConnection dBConnection = new DBConnection();
			TrainingMainDAO trainingMainDAO = DAOFactory.CreateTrainingMainDAO();
			try
			{
				TrainingMain trainingMain = trainingMainDAO.GetTrainingMainById(id, dBConnection);

				return trainingMain;
			}
			catch (Exception)
			{
				dBConnection.RollBack();
				return null;
			}
			finally
			{
				if (dBConnection.con.State == System.Data.ConnectionState.Open)
					dBConnection.Commit();
			}
		}
	}
}
