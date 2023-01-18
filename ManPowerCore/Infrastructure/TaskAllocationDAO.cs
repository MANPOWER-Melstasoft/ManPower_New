using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TaskAllocationDAO
    {

        int SaveTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection);

        int UpdateTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection);

        int UpdateTaskAllocation(int id, int status, string officer, string remarks, DBConnection dbConnection);

        int DeleteTaskAllocation(int id, DBConnection dbConnection);

        List<TaskAllocation> GetAllTaskAllocation(DBConnection dbConnection);

        List<TaskAllocation> GetTaskAllocationDme21Approve(int PositionId, DBConnection dbConnection);

        TaskAllocation GetTaskAllocation(int id, DBConnection dbConnection);

        List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId, DBConnection dbConnection);

        List<TaskAllocation> GetTaskAllocationDme22Approve(int PositionId, DBConnection dbConnection);

    }

    public class TaskAllocationDAOImpl : TaskAllocationDAO
    {

        public int getMaxTaskAllocationId(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM TASK_ALLOCATION";
            int orderId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (orderId == 0)
            {
                orderId = 1;
            }
            else
            {
                orderId += 1;
            }


            return orderId;
        }

        public List<TaskAllocation> GetTaskAllocationDme21Approve(int PositionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE DME21_Approved_by=" + PositionId + "AND STATUS_ID=" + 2010;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);
        }

        public List<TaskAllocation> GetTaskAllocationDme22Approve(int PositionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE DME22_Approved_by=" + PositionId + "AND STATUS_ID=" + 8;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);
        }

        public int SaveTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO TASK_ALLOCATION(DEPARTMENT_UNIT_POSSITIONS_ID,TASK_YEAR_MONTH" +
                                            ",CREATED_DATE,CREATED_USER,STATUS_ID,DME21_Recommended_by1,RECOMMENDED_DATE,DME22_Approved_by,APPROVED_DATE,DME21_Recommended_by2,DME21_Approved_by) " +
                                            "VALUES(@DepartmetUnitPossitionsId,@TaskYearMonth,@CreatedDate,@CreatedUser,@StatusId," +
                                            "@RecommendedBy1,@RecommendedDate,@ApprovedBy,@ApprovedDate, @dme21Rec2, @dme21ApprovedBy) SELECT SCOPE_IDENTITY()";




            dbConnection.cmd.Parameters.AddWithValue("@DepartmetUnitPossitionsId", taskAllocation.DepartmetUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@TaskYearMonth", taskAllocation.TaskYearMonth);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", taskAllocation.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", taskAllocation.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", taskAllocation.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy1", taskAllocation.DME21RecommendedBy1);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", taskAllocation.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", taskAllocation.DME22_ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", taskAllocation.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@dme21Rec2", taskAllocation.DME21RecommendedBy2);
            dbConnection.cmd.Parameters.AddWithValue("@dme21ApprovedBy", taskAllocation.DME21ApprovedBy);

            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE TASK_ALLOCATION SET DEPARTMENT_UNIT_POSSITIONS_ID = @DepartmetUnitPossitionsId, TASK_YEAR_MONTH = @TaskYearMonth " +
                                           ", CREATED_DATE = @CreatedDate, CREATED_USER = @CreatedUser, STATUS_ID = @StatusId, DME21_Recommended_by1 = @RecommendedBy1, " +
                                           "RECOMMENDED_DATE = @RecommendedDate, DME22_Approved_by = @ApprovedBy, APPROVED_DATE = @ApprovedDate,DME21_Recommended_by2 = @dme21Rec2,DME21_Approved_by = @dme21ApprovedBy WHERE ID = @TaskAllocationId ";

            dbConnection.cmd.Parameters.AddWithValue("@TaskAllocationId", taskAllocation.TaskAllocationId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmetUnitPossitionsId", taskAllocation.DepartmetUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@TaskYearMonth", taskAllocation.TaskYearMonth);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", taskAllocation.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", taskAllocation.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", taskAllocation.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy1", taskAllocation.DME21RecommendedBy1);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", taskAllocation.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", taskAllocation.DME22_ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", taskAllocation.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@dme21Rec2", taskAllocation.DME21RecommendedBy2);
            dbConnection.cmd.Parameters.AddWithValue("@dme21ApprovedBy", taskAllocation.DME21ApprovedBy);

            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int UpdateTaskAllocation(int id, int status, string officer, string remarks, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE TASK_ALLOCATION SET STATUS_ID = @StatusId, APPROVED_BY = @ApprovedBy, COMMENTS = @ApprovalComments  WHERE ID = @id ";


            dbConnection.cmd.Parameters.AddWithValue("@id", id);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", status);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", officer);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalComments", remarks);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<TaskAllocation> GetAllTaskAllocation(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);

        }

        public TaskAllocation GetTaskAllocation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE ID = " + id + " ";
            TaskAllocation taskAllocations = new TaskAllocation();

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();

            taskAllocations = dataAccessObject.GetSingleOject<TaskAllocation>(dbConnection.dr);
            return taskAllocations;

        }


        public List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE DEPARTMENT_UNIT_POSSITIONS_ID = " + departmentUnitPositionId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);

        }



        public int DeleteTaskAllocation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "DELETE FROM TASK_ALLOCATION WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return 1;

        }

    }
}
