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
    public interface JobRefferalsController
    {
        int SaveJobRefferals(JobRefferals jobRefferals);

        List<JobRefferals> GetAllJobRefferals();

        List<JobRefferals> GetAllJobRefferalsByBene(int BeneId);
    }

    public class JobRefferalsControllerImpl : JobRefferalsController
    {
        DBConnection dBConnection;
        JobRefferalsDAO aa = DAOFactory.CreateJobRefferalsDAO();

        public int SaveJobRefferals(JobRefferals jobRefferals)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = aa.SaveJobRefferals(jobRefferals, dBConnection);
                return result;
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

        public List<JobRefferals> GetAllJobRefferals()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                return aa.GetAllJobRefferals(dbConnection);
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

        public List<JobRefferals> GetAllJobRefferalsByBene(int BeneId)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<JobRefferals> jobRefferals = new List<JobRefferals>();
                jobRefferals = aa.GetAllJobRefferalsByBene(BeneId, dbConnection);

                ProgramPlanDAO programPlanDAO = DAOFactory.CreateProgramPlanDAO();
                foreach (var item in jobRefferals)
                {
                    if (item.ProgramPlanId != 0)
                    {
                        item.ProgramPlan = programPlanDAO.GetProgramPlan(item.ProgramPlanId, dbConnection);
                    }
                }

                CompanyVecansyRegistationDetailsDAO companyVecansyRegistationDetailsDAO = DAOFactory.CreateCompanyVecansyRegistationDetailsDAO();
                foreach (var item in jobRefferals)
                {
                    if (item.VacancyRegistrationId != 0)
                    {
                        item.companyVecansyRegistationDetails = companyVecansyRegistationDetailsDAO.GetCompanyVecansyRegistationDetails(item.VacancyRegistrationId, dbConnection);
                    }
                }

                JobCategoryDAO jobCategoryDAO = DAOFactory.CreateJobCategoryDAO();
                foreach (var item in jobRefferals)
                {
                    if (item.JobCategoryId != 0)
                    {
                        item.JobCategory = jobCategoryDAO.GetAllJobCategory(dbConnection).Where(x => x.JobCategoryId == item.JobCategoryId).Single();
                    }
                }

                return jobRefferals;
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

    }
}
