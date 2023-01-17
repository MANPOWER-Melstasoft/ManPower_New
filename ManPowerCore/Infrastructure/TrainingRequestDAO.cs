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
        int UpdateTrainingRequest(Training_Request trainingrequest, DBConnection dbConnection);

        Training_Request GetTrainingRequest(int requestTrainingID, DBConnection dbConnection);
    }

    public class TrainingRequestDAOImpl : TrainingRequestDAO
    {
        public List<Training_Request> GetAllTrainingRequests(DBConnection dbConnection)
        {
            List<Training_Request> trainingRequestList = new List<Training_Request>();
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TRAINING_REQUEST ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            trainingRequestList = dataAccessObject.ReadCollection<Training_Request>(dbConnection.dr);
            return trainingRequestList;

        }

        public int AddRequest(Training_Request trainingrequest, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO TRAINING_REQUEST(EMPLOYEE_ID,PROGRAM_DATE,PROGRAM_ID," +
                "REQUESTED_DATE,Requested_user_id,APPROVED_BY,APPROVED_DATE,Status_ID,Training_Category,Institute,Content_type,Doc_Upload) " +
                "VALUES('" + trainingrequest.Employee_Id + "','" + trainingrequest.ProgramDate + "','" + trainingrequest.ProgramId + "','" + trainingrequest.RequestedDate + "'," +
                "'" + trainingrequest.RequestedUserID + "', '" + trainingrequest.ApprovedBy + "', '" + trainingrequest.ApprovedDate + "', '" + trainingrequest.StatusID + "'," +
                " '" + trainingrequest.TrainingCategory + "','" + trainingrequest.Institute + "', '" + trainingrequest.Content + "', '" + trainingrequest.DocUpload + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateTrainingRequest(Training_Request trainingrequest, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE TRAINING_REQUEST SET EMPLOYEE_ID = @empId, PROGRAM_DATE = @programDate, PROGRAM_ID = @programId, " +
                "REQUESTED_DATE=@requestedDate, Requested_user_id=@requestedUserId, APPROVED_BY = @approvedBy, APPROVED_DATE=@approvedDate,Status_ID=@statusID," +
                "Training_Category=@trainingCategory, Institute=@institute,Content_type = @content, Doc_Upload=@doc  WHERE ID = @id ";


            dbConnection.cmd.Parameters.AddWithValue("@id", trainingrequest.TrainingRequestId);
            dbConnection.cmd.Parameters.AddWithValue("@empId", trainingrequest.Employee_Id);
            dbConnection.cmd.Parameters.AddWithValue("@programDate", trainingrequest.ProgramDate);
            dbConnection.cmd.Parameters.AddWithValue("@programId", trainingrequest.ProgramId);
            dbConnection.cmd.Parameters.AddWithValue("@requestedDate", trainingrequest.RequestedDate);
            dbConnection.cmd.Parameters.AddWithValue("@requestedUserId", trainingrequest.RequestedUserID);
            dbConnection.cmd.Parameters.AddWithValue("@approvedBy", trainingrequest.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@approvedDate", trainingrequest.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@statusID", trainingrequest.StatusID);
            dbConnection.cmd.Parameters.AddWithValue("@trainingCategory", trainingrequest.TrainingCategory);
            dbConnection.cmd.Parameters.AddWithValue("@institute", trainingrequest.Institute);
            dbConnection.cmd.Parameters.AddWithValue("@content", trainingrequest.Content);
            dbConnection.cmd.Parameters.AddWithValue("@doc", trainingrequest.DocUpload);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public Training_Request GetTrainingRequest(int requestTrainingID, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TRAINING_REQUEST WHERE Id=" + requestTrainingID;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Training_Request>(dbConnection.dr);
        }
    }
}
