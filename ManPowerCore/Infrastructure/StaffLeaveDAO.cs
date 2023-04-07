using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        int updateStaffLeaveRecommendation(StaffLeave staffLeave, DBConnection dbConnection);

        int updateStaffLeaveReject(StaffLeave staffLeave, DBConnection dbConnection);
    }
    public class StaffLeaveDAOSqlImpl : StaffLeaveDAO
    {
        public int saveStaffLeave(StaffLeave staffLeave, DBConnection dBConnection)
        {
            if (dBConnection.dr != null)
                dBConnection.dr.Close();

            dBConnection.cmd.CommandType = System.Data.CommandType.Text;

            dBConnection.cmd.Parameters.Clear();
            dBConnection.cmd.CommandText = "INSERT INTO Staff_Leave (Day_Type_id,Leave_Type_id,Employee_ID,Leave_Date,Created_Date,Is_Half_Day,Leave_Status_Id,Reason_For_Leave,Resuming_Date,No_Of_Leave,Leave_Document,From_Time,To_Time)" +
               " VALUES(@DayType,@LeaveTypeId,@EmpId,@LeaveDate,@CreatedDate,@IsHalfDay,@LeaveStatusId,@Reason,@ResumingDate,@NoLeaves,@LeaveDocument,@FromTime,@ToTime);";

            dBConnection.cmd.Parameters.AddWithValue("@LeaveTypeId", staffLeave.LeaveTypeId);
            dBConnection.cmd.Parameters.AddWithValue("@NoLeaves", staffLeave.NoOfLeaves);
            dBConnection.cmd.Parameters.AddWithValue("@ResumingDate", staffLeave.ResumingDate);
            dBConnection.cmd.Parameters.AddWithValue("@Reason", staffLeave.ReasonForLeave);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveDate", staffLeave.LeaveDate);
            dBConnection.cmd.Parameters.AddWithValue("@DayType", staffLeave.DayTypeId);
            dBConnection.cmd.Parameters.AddWithValue("@EmpId", staffLeave.EmployeeId);

            dBConnection.cmd.Parameters.AddWithValue("@CreatedDate", staffLeave.CreatedDate);
            dBConnection.cmd.Parameters.AddWithValue("@IsHalfDay", staffLeave.IsHalfDay);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveDocument", staffLeave.LeaveDocument);
            dBConnection.cmd.Parameters.AddWithValue("@LeaveStatusId", staffLeave.LeaveStatusId);

            dBConnection.cmd.Parameters.AddWithValue("@FromTime", staffLeave.FromTime);
            dBConnection.cmd.Parameters.AddWithValue("@ToTime", staffLeave.ToTime);



            return dBConnection.cmd.ExecuteNonQuery();

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


    }
}
