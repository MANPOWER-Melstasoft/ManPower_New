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
    public interface CareerKeyTestResultsController
    {
        int Save(CareerKeyTestResults careerKeyTestResults);
        int Update(CareerKeyTestResults careerKeyTestResults);
        int Delete(int id);
        List<CareerKeyTestResults> GetAllCareerKeyTestResults(bool with0);
        CareerKeyTestResults GetCareerKeyTestResults(int id);
    }

    public class CareerKeyTestResultsControllerSqlImpl : CareerKeyTestResultsController
    {
        CareerKeyTestResultsDAO careerKeyTestResultsDAO = DAOFactory.CreateCareerKeyTestResultsDAO();

        public int Save(CareerKeyTestResults careerKeyTestResults)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = careerKeyTestResultsDAO.Save(careerKeyTestResults, dbConnection);
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

        public int Update(CareerKeyTestResults careerKeyTestResults)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                int output = 0;
                output = careerKeyTestResultsDAO.Update(careerKeyTestResults, dbConnection);
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
                output = careerKeyTestResultsDAO.Delete(id, dbConnection);
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

        public List<CareerKeyTestResults> GetAllCareerKeyTestResults(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<CareerKeyTestResults> careerKeyTestResultsList = new List<CareerKeyTestResults>();
                careerKeyTestResultsList = careerKeyTestResultsDAO.GetAllCareerKeyTestResults(with0, dbConnection);
                return careerKeyTestResultsList;
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

        public CareerKeyTestResults GetCareerKeyTestResults(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                CareerKeyTestResults careerKeyTestResults = new CareerKeyTestResults();
                careerKeyTestResults = careerKeyTestResultsDAO.GetCareerKeyTestResults(id, dbConnection);
                return careerKeyTestResults;
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
