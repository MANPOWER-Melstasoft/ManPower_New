using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingRequestsAttachmentDAO
    {
        int Save(TrainingRequestsAttachment trainingRequestsAttachment, DBConnection dbConnection);

        //int Update(TrainingMain trainingMain, DBConnection dbConnection);

        List<TrainingRequestsAttachment> GetAllTrainingRequestsAttachment(DBConnection dbConnection);
    }

    public class TrainingRequestsAttachmentDAOSqlImpl : TrainingRequestsAttachmentDAO
    {
        public int Save(TrainingRequestsAttachment trainingRequestsAttachment, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Training_Request_Attachment (Training_Request_Id, Attchment) VALUES (@trainingRequestsId, @attachment) ";

            dbConnection.cmd.Parameters.AddWithValue("@trainingRequestsId", trainingRequestsAttachment.TrainingRequestID);
            dbConnection.cmd.Parameters.AddWithValue("@attachment", trainingRequestsAttachment.Attachment);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingRequestsAttachment> GetAllTrainingRequestsAttachment(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Request_Attachment";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingRequestsAttachment>(dbConnection.dr);
        }
    }
}
