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
    public interface TrainingRefferalsController
    {
        int Save(TrainingRefferals trainingRefferals);
        int Update(TrainingRefferals trainingRefferals);
        int Delete(int id);
        List<TrainingRefferals> GetAllTrainingRefferals(bool with0);
        TrainingRefferals GetTrainingRefferals(int id);
    }

    public class TrainingRefferalsControllerSqlImpl : TrainingRefferalsController
    {
        TrainingRefferalsDAO trainingRefferalsDAO = DAOFactory.CreateTrainingRefferalsDAO();

        public int Save(TrainingRefferals trainingRefferals)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = trainingRefferalsDAO.Save(trainingRefferals, dbConnection);
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

        public int Update(TrainingRefferals trainingRefferals)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = trainingRefferalsDAO.Update(trainingRefferals, dbConnection);
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
                output = trainingRefferalsDAO.Delete(id, dbConnection);
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

        public List<TrainingRefferals> GetAllTrainingRefferals(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<TrainingRefferals> trainingRefferalsList = new List<TrainingRefferals>();
                trainingRefferalsList = trainingRefferalsDAO.GetAllTrainingRefferals(with0, dbConnection);
                return trainingRefferalsList;
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

        public TrainingRefferals GetTrainingRefferals(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TrainingRefferals trainingRefferals = new TrainingRefferals();
                trainingRefferals = trainingRefferalsDAO.GetTrainingRefferals(id, dbConnection);
                return trainingRefferals;
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
