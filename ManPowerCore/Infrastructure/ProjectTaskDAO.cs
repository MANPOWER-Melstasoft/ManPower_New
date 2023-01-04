using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProjectTaskDAO
    {
        int saveProjectTask(ProjectTask projectTask, DBConnection dbConnection);
        List<ProjectTask> GetAllProjectTask(DBConnection dbConnection);
        ProjectTask GetProjectTask(int id, DBConnection dbConnection);

        List<ProjectTask> GetProjectTaskByTaskAllocationDetailId(int TaskAllocationDetailId, DBConnection dbConnection);
        List<ProjectTask> GetAllProjectTaskByProgramPlanId(int ProgramPlanId, DBConnection dbConnection);


    }


    public class ProjectTaskDAOImpl : ProjectTaskDAO
    {
        public int saveProjectTask(ProjectTask projectTask, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "INSERT INTO Project_Task (PROGRAM_PLAN_ID, TASK_ALLOCATION_DETAIL_ID) VALUES (@programPlanId, @taskAllocationDetailId)";

            dbConnection.cmd.Parameters.AddWithValue("@programPlanId", projectTask.ProgramPlanId);
            dbConnection.cmd.Parameters.AddWithValue("@taskAllocationDetailId", projectTask.TaskAllocationDetailId);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<ProjectTask> GetAllProjectTask(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }

        public ProjectTask GetProjectTask(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProjectTask>(dbConnection.dr);
        }

        public List<ProjectTask> GetProjectTaskByTaskAllocationDetailId(int TaskAllocationDetailId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE TASK_ALLOCATION_DETAIL_ID = " + TaskAllocationDetailId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }

        public List<ProjectTask> GetAllProjectTaskByProgramPlanId(int ProgramPlanId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE PROGRAM_PLAN_ID = " + ProgramPlanId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }
    }
}
