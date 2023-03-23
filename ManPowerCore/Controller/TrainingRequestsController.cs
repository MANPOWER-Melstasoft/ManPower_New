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
    public interface TrainingRequestsController
    {
        int Save(TrainingRequests trainingRequests);

        int Update(TrainingRequests trainingRequests);

        int UpdateRec(TrainingRequests trainingRequests);
        int Delete(TrainingRequests trainingRequests);

        List<TrainingRequests> GetAllTrainingRequests();

        List<TrainingRequests> GetAllTrainingRequestsBiMainId(int id);

        List<TrainingRequests> GetAllTrainingRequestsWithDetail();
    }

    public class TrainingRequestsControllerImpl : TrainingRequestsController
    {
        DBConnection dBConnection;
        TrainingRequestsDAO trainingRequestsDAO = DAOFactory.createTrainingRequestsDAO();
        public int Save(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.Save(trainingRequests, dBConnection);
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

        public int Update(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.Update(trainingRequests, dBConnection);
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

        public int Delete(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.Delete(trainingRequests, dBConnection);
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

        public int UpdateRec(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.UpdateRec(trainingRequests, dBConnection);
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

        public List<TrainingRequests> GetAllTrainingRequests()
        {
            try
            {
                dBConnection = new DBConnection();
                List<TrainingRequests> trainingRequestsList = trainingRequestsDAO.GetAllTrainingRequests(dBConnection);

                TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();
                List<TrainingMain> TrainingMainList = trainingMainController.GetAllTrainingMain();

                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);

                foreach (var item in trainingRequestsList)
                {
                    item.Trainingmain = TrainingMainList.Where(x => x.TrainingMainId == item.TrainingMainId).Single();
                }

                foreach (var item in trainingRequestsList)
                {
                    item.SystemUser = systemUserList.Where(x => x._DepartmentUnitPositions.DepartmetUnitPossitionsId == item.Created_User).Single();
                }

                return trainingRequestsList;
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

        public List<TrainingRequests> GetAllTrainingRequestsBiMainId(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                List<TrainingRequests> trainingRequestsList = trainingRequestsDAO.GetAllTrainingRequestsBiMainId(id, dBConnection);
                if (trainingRequestsList.Count != 0)
                {
                    TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();
                    List<TrainingMain> TrainingMainList = trainingMainController.GetAllTrainingMain();

                    SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                    List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);

                    foreach (var item in trainingRequestsList)
                    {
                        item.Trainingmain = TrainingMainList.Where(x => x.TrainingMainId == item.TrainingMainId).Single();
                    }

                    foreach (var item in trainingRequestsList)
                    {
                        item.SystemUser = systemUserList.Where(x => x._DepartmentUnitPositions.DepartmetUnitPossitionsId == item.Created_User).Single();
                    }
                }
                return trainingRequestsList;
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


        public List<TrainingRequests> GetAllTrainingRequestsWithDetail()
        {
            try
            {
                dBConnection = new DBConnection();
                List<TrainingRequests> trainingRequestsList = trainingRequestsDAO.GetAllTrainingRequests(dBConnection);

                ProjectStatusDAO projectstatusDAO = DAOFactory.CreateProjectStatusDAO();
                List<ProjectStatus> projectStatusList = projectstatusDAO.GetAllProjectStatus(dBConnection);

                TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();
                List<TrainingMain> TrainingMainList = trainingMainController.GetAllTrainingMain();

                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);

                foreach (var item in trainingRequestsList)
                {
                    item.Trainingmain = TrainingMainList.Where(x => x.TrainingMainId == item.TrainingMainId).Single();
                }

                foreach (var item in trainingRequestsList)
                {
                    item.ProjectStatus = projectStatusList.Where(x => x.ProjectStatusId == item.ProjectStatusId).Single();
                }

                foreach (var item in trainingRequestsList)
                {
                    item.SystemUser = systemUserList.Where(x => x._DepartmentUnitPositions.DepartmetUnitPossitionsId == item.Created_User).Single();
                }

                return trainingRequestsList;
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
