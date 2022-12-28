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
    public interface TrainingRequestController
    {
        List<Training_Request> GetAllTrainingRequests();
        int AddRequest(Training_Request trainingrequest);

        List<Training_Request> GetAllPendingTrainingRequest();

        List<Training_Request> GetAllApprovedTrainingRequest();

        List<Training_Request> GetOnlyPendingTrainingRequest();

        int UpdateTrainingRequest(Training_Request trainingrequest);

        Training_Request GetTraining_Request(int requestTrainingId);
    }

    public class TrainingRequestControllerImpl : TrainingRequestController
    {
        DBConnection dBConnection;
        TrainingRequestDAO trainingRequestDAO = DAOFactory.CreateTrainingRequestDAO();

        public List<Training_Request> GetAllTrainingRequests()
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.GetAllTrainingRequests(dBConnection);

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


        public int AddRequest(Training_Request trainingrequest)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.AddRequest(trainingrequest, dBConnection);
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

        public List<Training_Request> GetAllPendingTrainingRequest()
        {
            try
            {
                dBConnection = new DBConnection();
                List<Training_Request> trainingRequestList = trainingRequestDAO.GetAllTrainingRequests(dBConnection);
                List<Employee> employeeList = new List<Employee>();
                List<Program> programList = new List<Program>();
                List<ProjectStatus> statusList = new List<ProjectStatus>();

                EmployeeController employeeController = ControllerFactory.CreateEmployeeController();

                employeeList = employeeController.GetAllEmployees();

                ProgramController programController = ControllerFactory.CreateProgramController();

                programList = programController.GetAllProgram(false, false);

                ProjectStatusController statusController = ControllerFactory.CreateProjectStatusController();

                statusList = statusController.GetAllProjectStatus(false);

                trainingRequestList = trainingRequestList.Where(x => x.StatusID == 1 || x.StatusID == 7).ToList();

                foreach (var item in trainingRequestList)
                {
                    item.Employee = employeeList.Where(x => x.EmployeeId == item.Employee_Id).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Program = programList.Where(x => x.ProgramId == item.ProgramId).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Status = statusList.Where(x => x.ProjectStatusId == item.StatusID).Single();
                }

                return trainingRequestList;
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

        public List<Training_Request> GetAllApprovedTrainingRequest()
        {
            try
            {
                dBConnection = new DBConnection();
                List<Training_Request> trainingRequestList = trainingRequestDAO.GetAllTrainingRequests(dBConnection);
                List<Employee> employeeList = new List<Employee>();
                List<Program> programList = new List<Program>();
                List<ProjectStatus> statusList = new List<ProjectStatus>();

                EmployeeController employeeController = ControllerFactory.CreateEmployeeController();

                employeeList = employeeController.GetAllEmployees();

                ProgramController programController = ControllerFactory.CreateProgramController();

                programList = programController.GetAllProgram(false, false);

                ProjectStatusController statusController = ControllerFactory.CreateProjectStatusController();

                statusList = statusController.GetAllProjectStatus(false);

                trainingRequestList = trainingRequestList.Where(x => x.StatusID == 1008).ToList();

                foreach (var item in trainingRequestList)
                {
                    item.Employee = employeeList.Where(x => x.EmployeeId == item.Employee_Id).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Program = programList.Where(x => x.ProgramId == item.ProgramId).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Status = statusList.Where(x => x.ProjectStatusId == item.StatusID).Single();
                }

                return trainingRequestList;
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

        public List<Training_Request> GetOnlyPendingTrainingRequest()
        {
            try
            {
                dBConnection = new DBConnection();
                List<Training_Request> trainingRequestList = trainingRequestDAO.GetAllTrainingRequests(dBConnection);
                List<Employee> employeeList = new List<Employee>();
                List<Program> programList = new List<Program>();
                List<ProjectStatus> statusList = new List<ProjectStatus>();

                EmployeeController employeeController = ControllerFactory.CreateEmployeeController();

                employeeList = employeeController.GetAllEmployees();

                ProgramController programController = ControllerFactory.CreateProgramController();

                programList = programController.GetAllProgram(false, false);

                ProjectStatusController statusController = ControllerFactory.CreateProjectStatusController();

                statusList = statusController.GetAllProjectStatus(false);

                trainingRequestList = trainingRequestList.Where(x => x.StatusID == 1).ToList();

                foreach (var item in trainingRequestList)
                {
                    item.Employee = employeeList.Where(x => x.EmployeeId == item.Employee_Id).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Program = programList.Where(x => x.ProgramId == item.ProgramId).Single();
                }

                foreach (var item in trainingRequestList)
                {
                    item.Status = statusList.Where(x => x.ProjectStatusId == item.StatusID).Single();
                }

                return trainingRequestList;
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

        public int UpdateTrainingRequest(Training_Request trainingrequest)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.UpdateTrainingRequest(trainingrequest, dBConnection);

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

        public Training_Request GetTraining_Request(int requestTrainingId)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.GetTrainingRequest(requestTrainingId, dBConnection);

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
