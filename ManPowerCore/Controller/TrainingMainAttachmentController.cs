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
    public interface TrainingMainAttachmentController
    {
        int Save(TrainingMainAttachment trainingMainAttachment);

        //int Update(TrainingMain trainingMain);

        List<TrainingMainAttachment> GetAllTrainingMainAttachments();
    }

    public class TrainingMainAttachmentControllerImpl : TrainingMainAttachmentController
    {
        DBConnection dBConnection;

        TrainingMainAttachmentDAO trainingMainAttachmentDAO = DAOFactory.CreateTrainingMainAttachmentDAO();

        public int Save(TrainingMainAttachment trainingMainAttachment)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingMainAttachmentDAO.Save(trainingMainAttachment, dBConnection);
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

        public List<TrainingMainAttachment> GetAllTrainingMainAttachments()
        {
            try
            {
                dBConnection = new DBConnection();
                List<TrainingMainAttachment> trainingMainAttachments = trainingMainAttachmentDAO.GetAllTrainingMainAttachment(dBConnection);
                return trainingMainAttachments;
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
