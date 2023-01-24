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
    }
}
