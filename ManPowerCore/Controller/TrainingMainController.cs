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
    public interface TrainingMainController
    {
        int Save(TrainingMain trainingMain);

        int Update(TrainingMain trainingMain);

        List<TrainingMain> GetAllTrainingMain();
    }

    public class TrainingMainControllerImpl : TrainingMainController
    {
        DBConnection dBConnection;
        TrainingMainDAO trainingMainDAO = DAOFactory.CreateTrainingMainDAO();
        public int Save(TrainingMain trainingMain)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingMainDAO.Save(trainingMain, dBConnection);
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

        public int Update(TrainingMain trainingMain)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingMainDAO.Update(trainingMain, dBConnection);
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

        public List<TrainingMain> GetAllTrainingMain()
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingMainDAO.GetAllTrainingMain(dBConnection);
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
