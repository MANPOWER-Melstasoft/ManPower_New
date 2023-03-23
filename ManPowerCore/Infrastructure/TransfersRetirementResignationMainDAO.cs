using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TransfersRetirementResignationMainDAO
    {
        int Save(TransfersRetirementResignationMain obj, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int Approve(TransfersRetirementResignationMain obj, DBConnection dbConnection);
        int Recommend(TransfersRetirementResignationMain obj, DBConnection dbConnection);
        List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0, DBConnection dbConnection);
        TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id, DBConnection dbConnection);
    }

    public class TransfersRetirementResignationMainDAOSqlImpl : TransfersRetirementResignationMainDAO
    {

        public int Save(TransfersRetirementResignationMain obj, DBConnection dbConnection)
        {
            int output = 0;
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO Transfers_Retirement_Resignation_Main (Request_Type_Id, Status_Id, Employee_ID, Created_Date," +
                "Created_User, Documents, Parent_Id)" +
                "VALUES (@RequestTypeId, @StatusId, @EmployeeId, @CreatedDate, @CreatedUser, @Documents, @ParentId) SELECT SCOPE_IDENTITY()";

            dbConnection.cmd.Parameters.AddWithValue("@RequestTypeId", obj.RequestTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", obj.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", obj.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@Documents", obj.Documents);
            dbConnection.cmd.Parameters.AddWithValue("@ParentId", obj.ParentId);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            return output;
        }

        public int Approve(TransfersRetirementResignationMain obj, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfers_Retirement_Resignation_Main SET Request_Type_Id = @RequestTypeId, Status_Id = @StatusId," +
                "Employee_ID= @EmployeeId, Created_Date = @CreatedDate, Created_User = @CreatedUser, Documents = @Documents, Parent_Id = @ParentId," +
                "Parent_Action = @ParentAction, Action_Taken_User_Id = @ActionTakenUserId, Action_Taken_Date = @ActionTakenDate, Reason = @Reason, " +
                "Remarks = @Remarks WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", obj.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@RequestTypeId", obj.RequestTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", obj.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", obj.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@Documents", obj.Documents);
            dbConnection.cmd.Parameters.AddWithValue("@ParentId", obj.ParentId);
            dbConnection.cmd.Parameters.AddWithValue("@ParentAction", obj.ParentAction);
            dbConnection.cmd.Parameters.AddWithValue("@ActionTakenUserId", obj.ActionTakenUserId);
            dbConnection.cmd.Parameters.AddWithValue("@ActionTakenDate", obj.ActionTakenDate);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", obj.Reason);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public int Recommend(TransfersRetirementResignationMain obj, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfers_Retirement_Resignation_Main SET Request_Type_Id = @RequestTypeId, Status_Id = @StatusId," +
                "Employee_ID= @EmployeeId, Created_Date = @CreatedDate, Created_User = @CreatedUser, Documents = @Documents," +
                "Parent_Action = @ParentAction, Reason = @Reason, " +
                "Remarks = @Remarks, Recomend_Parent_Id = @RecomendParentId WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", obj.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@RequestTypeId", obj.RequestTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", obj.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", obj.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@Documents", obj.Documents);
            dbConnection.cmd.Parameters.AddWithValue("@RecomendParentId", obj.RecomendParentId);
            dbConnection.cmd.Parameters.AddWithValue("@ParentAction", obj.ParentAction);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", obj.Reason);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfers_Retirement_Resignation_Main SET Is_Active = 0 WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", id);


            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Main";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Main WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TransfersRetirementResignationMain>(dbConnection.dr);
        }

        public TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Main WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TransfersRetirementResignationMain>(dbConnection.dr);
        }

    }
}
