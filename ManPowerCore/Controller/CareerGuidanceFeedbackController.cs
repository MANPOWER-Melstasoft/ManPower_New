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
    public interface CareerGuidanceFeedbackController
    {
        int Save(CareerGuidanceFeedback careerGuidanceFeedback);
        int Update(CareerGuidanceFeedback careerGuidanceFeedback);
        int Delete(int id);
        List<CareerGuidanceFeedback> GetAllCareerKeyTestResults(bool with0);
        CareerGuidanceFeedback GetCareerKeyTestResults(int id);
    }

    public class CareerGuidanceFeedbackControllerSqlImpl : CareerGuidanceFeedbackController
    {
        CareerGuidanceFeedbackDAO careerGuidanceFeedbackDAO = DAOFactory.CreateCareerGuidanceFeedbackDAO();

        public int Save(CareerGuidanceFeedback careerGuidanceFeedback)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = careerGuidanceFeedbackDAO.Save(careerGuidanceFeedback, dbConnection);
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

        public int Update(CareerGuidanceFeedback careerGuidanceFeedback)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = careerGuidanceFeedbackDAO.Update(careerGuidanceFeedback, dbConnection);
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
                output = careerGuidanceFeedbackDAO.Delete(id, dbConnection);
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

        public List<CareerGuidanceFeedback> GetAllCareerKeyTestResults(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<CareerGuidanceFeedback> careerGuidanceFeedbacks = new List<CareerGuidanceFeedback>();
                careerGuidanceFeedbacks = careerGuidanceFeedbackDAO.GetAllCareerGuidanceFeedback(with0, dbConnection);
                return careerGuidanceFeedbacks;
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

        public CareerGuidanceFeedback GetCareerKeyTestResults(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                CareerGuidanceFeedback careerGuidanceFeedback = new CareerGuidanceFeedback();
                careerGuidanceFeedback = careerGuidanceFeedbackDAO.GetCareerGuidanceFeedback(id, dbConnection);
                return careerGuidanceFeedback;
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
