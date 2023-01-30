using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProjectPlanResourceDAO
    {
        int SaveProjectPlanResource(ProjectPlanResource projectPlanResource, DBConnection dbConnection);

        List<ProjectPlanResource> GetAllProjectPlanResources(DBConnection dbConnection);

        List<ProjectPlanResource> GetAllProjectPlanResourcesByProjectPlanId(int programTarget, DBConnection dbConnection);

        //int SaveProjectPlanResourceByList(List<ProjectPlanResource> projectPlanResource, DBConnection dbConnection);
    }

    public class ProjectPlanResourceDAOImpl : ProjectPlanResourceDAO
    {
        public int SaveProjectPlanResource(ProjectPlanResource projectPlanResource, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Resource_Person_Program_Plan(Resourse_Person_Id,Program_Plan_Id) values(@RESOURCE_PERSON_ID,@PROGRAM_PLAN_ID)";


            dbConnection.cmd.Parameters.AddWithValue("@RESOURCE_PERSON_ID", projectPlanResource.ResourcePersonId);
            dbConnection.cmd.Parameters.AddWithValue("@PROGRAM_PLAN_ID", projectPlanResource.ProgramPlanId);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            int result = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
            return result;
        }

        public List<ProjectPlanResource> GetAllProjectPlanResources(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Resource_Person_Program_Plan ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectPlanResource>(dbConnection.dr);
        }

        public List<ProjectPlanResource> GetAllProjectPlanResourcesByProjectPlanId(int planId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Resource_Person_Program_Plan Where Program_Plan_Id=" + planId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectPlanResource>(dbConnection.dr);
        }
        //public int SaveProjectPlanResourceByList(List<ProjectPlanResource> projectPlanResource, DBConnection dbConnection)
        //{
        //    if (dbConnection.dr != null)
        //        dbConnection.dr.Close();

        //    dbConnection.cmd.Parameters.Clear();
        //    dbConnection.cmd.CommandType = System.Data.CommandType.Text;
        //    dbConnection.cmd.CommandText = "INSERT INTO Resource_Person_Program_Plan(RESOURCE_PERSON_ID,PROGRAM_PLAN_ID) values(@RESOURCE_PERSON_ID,@PROGRAM_PLAN_ID) SELECT SCOPE_IDENTITY()";

        //    foreach (var item in projectPlanResource)
        //    {
        //        dbConnection.cmd.Parameters.AddWithValue("@RESOURCE_PERSON_ID", item.ResourcePersonId);
        //        dbConnection.cmd.Parameters.AddWithValue("@PROGRAM_PLAN_ID", item.ProgramPlanId);
        //        dbConnection.cmd.ExecuteNonQuery();
        //    }

        //    return 1;
        //}
    }
}
