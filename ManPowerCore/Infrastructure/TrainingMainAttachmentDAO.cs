using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingMainAttachmentDAO
    {
        int Save(TrainingMainAttachment trainingMainAttachment, DBConnection dbConnection);

        //int Update(TrainingMain trainingMain, DBConnection dbConnection);

        List<TrainingMainAttachment> GetAllTrainingMainAttachment(DBConnection dbConnection);
    }

    public class TrainingMainAttachmentDAOSqlImpl : TrainingMainAttachmentDAO
    {
        public int Save(TrainingMainAttachment trainingMainAttachment, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Training_Main_Attachment (Training_Main_Id, Attchment) VALUES (@trainingMainId, @attachment) ";

            dbConnection.cmd.Parameters.AddWithValue("@trainingMainId", trainingMainAttachment.TrainingMainId);
            dbConnection.cmd.Parameters.AddWithValue("@attachment", trainingMainAttachment.Attachment);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingMainAttachment> GetAllTrainingMainAttachment(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Main_Attachment";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingMainAttachment>(dbConnection.dr);
        }
    }
}
