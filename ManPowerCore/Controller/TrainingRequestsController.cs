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
    public interface TrainingRequestsController
    {
        int Save(TrainingRequests trainingRequests);

        int Update(TrainingRequests trainingRequests);

        List<TrainingRequests> GetAllTrainingRequests();
    }

    public class TrainingRequestsControllerImpl : TrainingRequestsController
    {
        DBConnection dBConnection;
        TrainingRequestsDAO trainingRequestsDAO = DAOFactory.createTrainingRequestsDAO();
        public int Save(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.Save(trainingRequests, dBConnection);
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

        public int Update(TrainingRequests trainingRequests)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.Update(trainingRequests, dBConnection);
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

        public List<TrainingRequests> GetAllTrainingRequests()
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsDAO.GetAllTrainingRequests(dBConnection);
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
