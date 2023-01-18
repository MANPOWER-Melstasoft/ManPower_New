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
    public interface TrainingRefferalFeedbackController
    {
        int Save(TrainingRefferalFeedback trainingRefferalFeedback);
        int Update(TrainingRefferalFeedback trainingRefferalFeedback);
        int Delete(int id);
        List<TrainingRefferalFeedback> GetAllTrainingRefferalFeedback(bool with0);
        TrainingRefferalFeedback GetTrainingRefferalFeedback(int id);
    }

    public class TrainingRefferalFeedbackControllerSqlImpl : TrainingRefferalFeedbackController
    {
        TrainingRefferalFeedbackDAO trainingRefferalFeedbackDAO = DAOFactory.CreateTrainingRefferalFeedbackDAO();

        public int Save(TrainingRefferalFeedback trainingRefferals)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = trainingRefferalFeedbackDAO.Save(trainingRefferals, dbConnection);
                return output;
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

        public int Update(TrainingRefferalFeedback trainingRefferals)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = trainingRefferalFeedbackDAO.Update(trainingRefferals, dbConnection);
                return output;
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
        public int Delete(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = trainingRefferalFeedbackDAO.Delete(id, dbConnection);
                return output;
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

        public List<TrainingRefferalFeedback> GetAllTrainingRefferalFeedback(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<TrainingRefferalFeedback> trainingRefferalFeedbackList = new List<TrainingRefferalFeedback>();
                trainingRefferalFeedbackList = trainingRefferalFeedbackDAO.GetAllTrainingRefferalFeedback(with0, dbConnection);
                return trainingRefferalFeedbackList;
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

        public TrainingRefferalFeedback GetTrainingRefferalFeedback(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TrainingRefferalFeedback trainingRefferalFeedback = new TrainingRefferalFeedback();
                trainingRefferalFeedback = trainingRefferalFeedbackDAO.GetTrainingRefferalFeedback(id, dbConnection);
                return trainingRefferalFeedback;
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
