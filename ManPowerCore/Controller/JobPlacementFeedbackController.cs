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
    public interface JobPlacementFeedbackController
    {
        int SaveJobPlacementFeedback(JobPlacementFeedback jobPlacementFeedback);

        List<JobPlacementFeedback> GetAllJobPlacementFeedback();
    }

    public class JobPlacementFeedbackControllerImpl : JobPlacementFeedbackController
    {
        DBConnection dBConnection;
        JobPlacementFeedbackDAO aa = DAOFactory.CreateJobPlacementFeedbackDAO();

        public int SaveJobPlacementFeedback(JobPlacementFeedback jobPlacementFeedback)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = aa.SaveJobPlacementFeedback(jobPlacementFeedback, dBConnection);
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

        public List<JobPlacementFeedback> GetAllJobPlacementFeedback()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                return aa.GetAllJobPlacementFeedback(dbConnection);
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
