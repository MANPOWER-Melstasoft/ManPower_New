using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface StaffLeaveDAO
    {
        int saveStaffLeave(StaffLeave staffLeave, DBConnection dBConnection);
        int saveStaffLeaveDoc(StaffLeave staffLeave, DBConnection dBConnection);

        List<StaffLeave> getStaffLeaves(DBConnection dbConnection);

        StaffLeave getStaffLeaveById(int id, DBConnection dbConnection);

        int updateStaffLeave(StaffLeave staffLeave, DBConnection dbConnection);

        int updateStaffLeaveSubmit(StaffLeave staffLeave, DBConnection dbConnection);

        int updateStaffLeaveRecommendation(StaffLeave staffLeave, DBConnection dbConnection);

        int updateStaffLeaveReject(StaffLeave staffLeave, DBConnection dbConnection);

        DataTable getRemainLeaveByEmpAndYear(int Emp, int Year, int LeaveType, DBConnection dBConnection);

    }
    public class StaffLeaveDAOSqlImpl : StaffLeaveDAO
    {
        public int saveStaffLeave(StaffLeave staffLeave, DBConnection dBConnection)
        {
            int output = 0;
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.CommandType = System.Data.CommandType.Text;

            dBConnection.cmd.Parameters.Clear();
            dBConnection.cmd.CommandText = "INSERT INTO Staff_Leave (Day_Type_id,Leave_Type_id,Employee_ID,Leave_Date,Created_Date,Is_Half_Day,Leave_Status_Id,Reason_For_Leave,Resuming_Date,No_Of_Leave,From_Time,To_Time)" +
               " VALUES(@DayType,@LeaveTypeId,@EmpId,@LeaveDate,@CreatedDate,@IsHalfDay,@LeaveStatusId,@Reason,@ResumingDate,@NoLeaves,@FromTime,@ToTime) SELECT SCOPE_IDENTITY();";

            dBConnection.cmd.Parameters.AddWithValue("@LeaveTypeId", staffLeave.LeaveTypeId);
            dBConnection.cmd.Parameters.AddWithValue("@NoLeaves", staffLeave.NoOfLeaves);
            dBConnection.cmd.Parameters.AddWithValue("@ResumingDate", staffLeave.ResumingDate);
            dBConnection.cmd.Parameters.AddWithValue("@Reason", staffLeave.ReasonForLeave);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveDate", staffLeave.LeaveDate);
            dBConnection.cmd.Parameters.AddWithValue("@DayType", staffLeave.DayTypeId);
            dBConnection.cmd.Parameters.AddWithValue("@EmpId", staffLeave.EmployeeId);

            dBConnection.cmd.Parameters.AddWithValue("@CreatedDate", staffLeave.CreatedDate);
            dBConnection.cmd.Parameters.AddWithValue("@IsHalfDay", staffLeave.IsHalfDay);
            //dBConnection.cmd.Parameters.AddWithValue("@LeaveDocument", staffLeave.LeaveDocument);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);

            dBConnection.cmd.Parameters.AddWithValue("@FromTime", staffLeave.FromTime);
            dBConnection.cmd.Parameters.AddWithValue("@ToTime", staffLeave.ToTime);

            output = Convert.ToInt32(dBConnection.cmd.ExecuteScalar());

            return output;

        }

        public int saveStaffLeaveDoc(StaffLeave staffLeave, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.CommandType = System.Data.CommandType.Text;

            dBConnection.cmd.Parameters.Clear();
            dBConnection.cmd.CommandText = "INSERT INTO Staff_Leave (Employee_ID, Leave_Status_Id, Leave_Document)" +
               " VALUES(@EmpId, @LeaveStatusId, @LeaveDocument);";


            dBConnection.cmd.Parameters.AddWithValue("@EmpId", staffLeave.EmployeeId);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveDocument", staffLeave.LeaveDocument);

            return dBConnection.cmd.ExecuteNonQuery();

        }

        public List<StaffLeave> getStaffLeaves(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Staff_Leave";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<StaffLeave>(dbConnection.dr);
        }

        public StaffLeave getStaffLeaveById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Staff_Leave WHERE Id=" + id + "";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<StaffLeave>(dbConnection.dr);
        }

        public int updateStaffLeaveSubmit(StaffLeave staffLeave, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Staff_Leave SET Day_Type_id = @DayType, Leave_Type_id = @LeaveTypeId, Leave_Date = @LeaveDate, " +
                "Created_Date = @CreatedDate, Is_Half_Day = @IsHalfDay, Leave_Status_Id = @LeaveStatusId, Reason_For_Leave = @Reason, " +
                "Resuming_Date = @ResumingDate, No_Of_Leave = @NoLeaves, From_Time = @FromTime, To_Time = @ToTime, Approved_By=@ApprovedBy, " +
                "Approved_Date=@ApproveDate WHERE ID = @StaffLeaveId;";

            dbConnection.cmd.Parameters.AddWithValue("@DayType", staffLeave.DayTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@LeaveTypeId", staffLeave.LeaveTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@LeaveDate", staffLeave.LeaveDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", staffLeave.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@IsHalfDay", staffLeave.IsHalfDay);
            dbConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", staffLeave.ReasonForLeave);
            dbConnection.cmd.Parameters.AddWithValue("@ResumingDate", staffLeave.ResumingDate);
            dbConnection.cmd.Parameters.AddWithValue("@NoLeaves", staffLeave.NoOfLeaves);
            dbConnection.cmd.Parameters.AddWithValue("@FromTime", staffLeave.FromTime);
            dbConnection.cmd.Parameters.AddWithValue("@ToTime", staffLeave.ToTime);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", staffLeave.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApproveDate", staffLeave.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@StaffLeaveId", staffLeave.StaffLeaveId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int updateStaffLeave(StaffLeave staffLeave, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Staff_Leave SET Approved_By=@ApprovedBy, Approved_Date=@ApproveDate,Leave_Status_Id=@LeaveStatusId WHERE Id=@StaffLeaveId ";

            dbConnection.cmd.Parameters.AddWithValue("@StaffLeaveId", staffLeave.StaffLeaveId);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", staffLeave.ApprovedBy);
            if (staffLeave.ApprovedDate.Year != 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@ApproveDate", staffLeave.ApprovedDate);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@ApproveDate", SqlDateTime.Null);

            }
            dbConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);



            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int updateStaffLeaveRecommendation(StaffLeave staffLeave, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Staff_Leave SET Recommended_BY=@RecommendedBy, Recommended_Date=@RecomennededDate,Leave_Status_Id=@LeaveStatusId WHERE Id=@StaffLeaveId ";

            dbConnection.cmd.Parameters.AddWithValue("@StaffLeaveId", staffLeave.StaffLeaveId);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", staffLeave.RecommendedBy);

            if (staffLeave.RecomennededDate.Year != 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@RecomennededDate", staffLeave.RecomennededDate);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@RecomennededDate", SqlDateTime.Null);

            }
            dbConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int updateStaffLeaveReject(StaffLeave staffLeave, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE Staff_Leave SET Leave_Status_Id=@LeaveStatusId,Reject_Reason=@RejectReason WHERE Id=@StaffLeaveId ";

            dbConnection.cmd.Parameters.AddWithValue("@StaffLeaveId", staffLeave.StaffLeaveId);

            dbConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", staffLeave.RejectReason);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public DataTable getRemainLeaveByEmpAndYear(int Emp, int Year, int LeaveType, DBConnection dBConnection)
        {
            DataTable tableLeaveBalance = new DataTable();
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.Parameters.Clear();
            dBConnection.cmd.CommandText = "SELECT (SELECT ISNULL(SUM(CAST(Entitlement AS INT)), 0) FROM Staff_Leave_Allocation " +
                "WHERE Leave_Type_id = @LeaveType AND Leave_Year = @Year AND Employee_ID = @Emp) - " +
                "(SELECT ISNULL(SUM(No_Of_Leave), 0) FROM Staff_Leave WHERE Leave_Status_Id = 4 AND Leave_Type_id = @LeaveType AND YEAR(Leave_Date) = @Year AND Employee_ID = @Emp) AS Balance;";

            dBConnection.cmd.Parameters.AddWithValue("@Emp", Emp);
            dBConnection.cmd.Parameters.AddWithValue("@Year", Year);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveType", LeaveType);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dBConnection.cmd);
            dataAdapter.Fill(tableLeaveBalance);

            return tableLeaveBalance;
        }


    }
}
