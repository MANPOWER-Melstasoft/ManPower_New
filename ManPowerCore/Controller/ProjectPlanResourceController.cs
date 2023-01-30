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
    public interface ProjectPlanResourceController
    {
        int SaveProjectPlanResource(ProjectPlanResource projectPlanResource);
        int SaveProjectPlanResourceByList(int programPlanId, List<string> projectPlanResourceStringList);

        List<ProjectPlanResource> GetAllProjectPlanResources();

        List<ProjectPlanResource> GetAllProjectPlanResourcesByProgramPlanId(int programPlanId);
    }

    public class ProjectPlanResourceControllerImpl : ProjectPlanResourceController
    {
        DBConnection dBConnection;
        ProjectPlanResourceDAO ProjectPlanResourceDAO = DAOFactory.CreateProjectPlanResourceDAO();

        public int SaveProjectPlanResource(ProjectPlanResource projectPlanResource)
        {

            try
            {
                dBConnection = new DBConnection();
                return ProjectPlanResourceDAO.SaveProjectPlanResource(projectPlanResource, dBConnection);
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

        public int SaveProjectPlanResourceByList(int programPlanId, List<string> projectPlanResourceStringList)
        {
            try
            {
                dBConnection = new DBConnection();

                foreach (var item in projectPlanResourceStringList)
                {
                    ProjectPlanResource projectPlanResource = new ProjectPlanResource();
                    projectPlanResource.ProgramPlanId = programPlanId;
                    projectPlanResource.ResourcePersonPlanId = Convert.ToInt32(item);

                    ProjectPlanResourceDAO.SaveProjectPlanResource(projectPlanResource, dBConnection);
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

        public List<ProjectPlanResource> GetAllProjectPlanResources()
        {
            try
            {
                dBConnection = new DBConnection();


                return ProjectPlanResourceDAO.GetAllProjectPlanResources(dBConnection);
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

        public List<ProjectPlanResource> GetAllProjectPlanResourcesByProgramPlanId(int programPlanId)
        {
            try
            {
                dBConnection = new DBConnection();


                return ProjectPlanResourceDAO.GetAllProjectPlanResourcesByProjectPlanId(programPlanId, dBConnection);
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
