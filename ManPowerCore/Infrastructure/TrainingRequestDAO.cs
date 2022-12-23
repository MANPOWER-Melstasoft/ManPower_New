using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingRequestDAO
    {
        List<Training_Request> GetAllTrainingRequests(DBConnection dbConnection);
        int AddRequest(Training_Request trainingrequest, DBConnection dbConnection);
    }

    public class TrainingRequestDAOImpl : TrainingRequestDAO
    {
        public List<Training_Request> GetAllTrainingRequests(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TRAINING_REQUEST ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Training_Request>(dbConnection.dr);

        }

        public int AddRequest(Training_Request trainingrequest, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO TRAINING_REQUEST(EMPLOYEE_ID,PROGRAM_DATE,PROGRAM_ID,REQUESTED_DATE,Requested_user_id,APPROVED_BY,APPROVED_DATE,Status_ID,Training_Category,Institute,Content_type,Doc_Upload) VALUES('" + trainingrequest.Employee_Id + "','" + trainingrequest.ProgramDate + "','" + trainingrequest.ProgramId + "','" + trainingrequest.RequestedDate + "','" + trainingrequest.RequestedUserID + "', '" + trainingrequest.ApprovedBy + "', '" + trainingrequest.ApprovedDate + "', '" + trainingrequest.StatusID + "', '" + trainingrequest.TrainingCategory + "','" + trainingrequest.Institute + "', '" + trainingrequest.Content + "', '" + trainingrequest.DocUpload + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }
    }
}
