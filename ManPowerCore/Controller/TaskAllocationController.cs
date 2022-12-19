﻿using ManPowerCore.Common;
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
    public interface TaskAllocationController
    {

        int SaveTaskAllocation(TaskAllocation taskAllocation);

        int UpdateTaskAllocation(TaskAllocation taskAllocation);

        int UpdateTaskAllocationApproval(int id, int status, string officer, string remarks);

        int saveTaskAllocation(TaskAllocation taskAllocation);

        List<TaskAllocation> GetAllTaskAllocation(bool withTaskAllocationDetail, bool withDepartmentUnitPositions, bool withProjectStatus, bool withTaskType);

        TaskAllocation GetTaskAllocation(int id, bool withTaskAllocationDetail, bool withDepartmentUnitPositions);

        List<TaskAllocation> GetTaskAllocationDme21Approve(int PositionId);

        List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId);
        List<TaskAllocation> GetAllTaskAllocationWithDepartmentUnitPosition();


        List<TaskAllocation> GetTaskAllocationDme22Approve(int PositionId);

    }


    public class TaskAllocationControllerImpl : TaskAllocationController
    {

        DBConnection dBConnection;
        TaskAllocationDAO taskAllocationDAO = DAOFactory.CreateTaskAllocationDAO();


        public int SaveTaskAllocation(TaskAllocation taskAllocation)
        {

            try
            {
                int id = 0;

                foreach (var j in taskAllocation._TaskAllocationDetail)
                {
                    dBConnection = new DBConnection();
                    List<TaskAllocation> list = taskAllocationDAO.GetAllTaskAllocation(dBConnection);
                    if (list.Where(u => u.TaskYearMonth.Month == j.StartTime.Month
                    && u.CreatedUser == taskAllocation.CreatedUser).Count() != 0)
                    {
                        foreach (var prop in list.Where(u => u.TaskYearMonth.Month == j.StartTime.Month && u.CreatedUser == taskAllocation.CreatedUser))
                        {
                            id = prop.TaskAllocationId;
                        }
                    }
                    else
                    {
                        dBConnection = new DBConnection();
                        id = taskAllocationDAO.SaveTaskAllocation(taskAllocation, dBConnection);
                    }
                }

                if (taskAllocation._TaskAllocationDetail.Count > 0)
                {
                    TaskAllocationDetailDAO taskAllocationDetail = DAOFactory.CreateTaskAllocationDetailDAO();
                    foreach (var i in taskAllocation._TaskAllocationDetail)
                    {
                        i.TaskAllocationId = id;
                        taskAllocationDetail.SaveTaskAllocationDetail(i, dBConnection);
                    }
                }



                return 1;
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
        public List<TaskAllocation> GetAllTaskAllocationWithDepartmentUnitPosition()
        {
            try
            {
                dBConnection = new DBConnection();
                DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                List<TaskAllocation> taskAllocationList = taskAllocationDAO.GetAllTaskAllocation(dBConnection).ToList();
                List<DepartmentUnitPositions> departmentUnitPositions = departmentUnitPositionsDAO.GetAllDepartmentUnitPositions(dBConnection).ToList();

                foreach (var item in taskAllocationList)
                {
                    item._DepartmentUnitPositions = departmentUnitPositions.Where(x => x.DepartmetUnitPossitionsId == item.DepartmetUnitPossitionsId).Single();
                }
                return taskAllocationList;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dBConnection.Commit();
                }
            }
        }

        public List<TaskAllocation> GetTaskAllocationDme21Approve(int PositionId)
        {

            try
            {
                dBConnection = new DBConnection();

                List<TaskAllocation> list = taskAllocationDAO.GetTaskAllocationDme21Approve(PositionId, dBConnection);


                DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();

                List<DepartmentUnitPositions> departmentUnitPositionList = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositions(dBConnection);

                foreach (var item in list)
                {
                    item._DepartmentUnitPositions = departmentUnitPositionList.Where(x => x.PossitionsId == item.DepartmetUnitPossitionsId).Single();
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

        public List<TaskAllocation> GetTaskAllocationDme22Approve(int PositionId)
        {

            try
            {
                dBConnection = new DBConnection();

                List<TaskAllocation> list = taskAllocationDAO.GetTaskAllocationDme22Approve(PositionId, dBConnection);


                DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();

                List<DepartmentUnitPositions> departmentUnitPositionList = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositions(dBConnection);

                foreach (var item in list)
                {
                    item._DepartmentUnitPositions = departmentUnitPositionList.Where(x => x.PossitionsId == item.DepartmetUnitPossitionsId).Single();
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
        public int saveTaskAllocation(TaskAllocation taskAllocation)
        {
            try
            {
                dBConnection = new DBConnection();
                return taskAllocationDAO.SaveTaskAllocation(taskAllocation, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dBConnection.Commit();
                }
            }
        }

        public int UpdateTaskAllocation(TaskAllocation taskAllocation)
        {

            try
            {
                dBConnection = new DBConnection();
                var taskAllocations = taskAllocationDAO.UpdateTaskAllocation(taskAllocation, dBConnection);
                return taskAllocations;
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


        public int UpdateTaskAllocationApproval(int id, int status, string officer, string remarks)
        {

            try
            {
                dBConnection = new DBConnection();
                var taskAllocations = taskAllocationDAO.UpdateTaskAllocation(id, status, officer, remarks, dBConnection);
                return taskAllocations;
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


        public List<TaskAllocation> GetAllTaskAllocation(bool withTaskAllocationDetail, bool withDepartmentUnitPositions, bool withProjectStatus, bool withTaskType)
        {
            try
            {
                dBConnection = new DBConnection();
                List<TaskAllocation> list = taskAllocationDAO.GetAllTaskAllocation(dBConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailDAO = DAOFactory.CreateTaskAllocationDetailDAO();

                    foreach (var item in list)
                    {
                        item._TaskAllocationDetail = _TaskAllocationDetailDAO.GetAllTaskAllocationDetailByTaskAllocationId(item.TaskAllocationId, dBConnection);
                    }
                }


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();

                    List<DepartmentUnitPositions> departmentUnitPositionList = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositions(dBConnection);

                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = departmentUnitPositionList.Where(x => x.DepartmetUnitPossitionsId == item.DepartmetUnitPossitionsId).Single();
                    }
                }

                if (withTaskAllocationDetail)
                {
                    ProjectStatusDAO _ProjectStatusDAO = DAOFactory.CreateProjectStatusDAO();
                    foreach (var item in list)
                    {
                        item._ProjectStatus = _ProjectStatusDAO.GetProjectStatus(item.TaskAllocationId, dBConnection);
                    }
                }

                if (withTaskType)
                {
                    TaskTypeDAO _TaskTypeDAO = DAOFactory.CreateTaskTypeDAO();
                    foreach (var item in list)
                    {
                        item._TaskType = _TaskTypeDAO.GetTaskType(item.TaskAllocationId, dBConnection);
                    }
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

        public TaskAllocation GetTaskAllocation(int id, bool withTaskAllocationDetail, bool withDepartmentUnitPositions)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TaskAllocationDAO DAO = DAOFactory.CreateTaskAllocationDAO();
                TaskAllocation _TaskAllocation = DAO.GetTaskAllocation(id, dbConnection);


                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailController = DAOFactory.CreateTaskAllocationDetailDAO();
                    _TaskAllocation._TaskAllocationDetail = _TaskAllocationDetailController.GetAllTaskAllocationDetailByTaskAllocationId(_TaskAllocation.TaskAllocationId, dbConnection);

                }


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _TaskAllocation._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetDepartmentUnitPositions(_TaskAllocation.TaskAllocationId, dbConnection);

                }



                return _TaskAllocation;
            }
            catch (Exception ex)
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

        public List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId)
        {
            try
            {
                dBConnection = new DBConnection();
                return taskAllocationDAO.GetAllTaskAllocationByDepartmentUnitPositionId(departmentUnitPositionId, dBConnection);

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

