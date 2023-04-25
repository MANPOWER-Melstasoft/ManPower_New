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
    public interface TrainingRequestsAttachmentController
    {
        int Save(TrainingRequestsAttachment trainingRequestsAttachment);

        //int Update(TrainingMain trainingMain);

        List<TrainingRequestsAttachment> GetAllTrainingRequestsAttachments();
    }

    public class TrainingRequestsAttachmentControllerImpl : TrainingRequestsAttachmentController
    {
        DBConnection dBConnection;

        TrainingRequestsAttachmentDAO trainingRequestsAttachmentDAO = DAOFactory.CreateTrainingRequestsAttachmentDAO();
        public int Save(TrainingRequestsAttachment trainingRequestsAttachment)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsAttachmentDAO.Save(trainingRequestsAttachment, dBConnection);
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

        public List<TrainingRequestsAttachment> GetAllTrainingRequestsAttachments()
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestsAttachmentDAO.GetAllTrainingRequestsAttachment(dBConnection);
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
