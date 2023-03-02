using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace ManPowerCore.Infrastructure
{
    public interface ProgramTargetDAO
    {
        List<ProgramTarget> GetAllProgramTarget(DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetByProgramId(int programId, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetByProgramTypeId(int programtypeId, DBConnection dbConnection);

        ProgramTarget GetProgramTarget(int id, DBConnection dbConnection);

        int SaveProgramTarget(ProgramTarget programTarget, DBConnection dbConnection);

        int UpdateProgramTarget(ProgramTarget programTarget, DBConnection dbConnection);


        int UpdateIsView(int programTargetId, DBConnection dbConnection);


        int UpdateProgramTargetApproval(int id, int status, string reason, DBConnection dbConnection);
        int UpdateProgramTargetApprovalRecomended(int id, int recomendedby, int status, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetFilter(int runYear, int runMonth, DBConnection dbConnection);

        List<ProgramTarget> UpcomingFilter(DateTime startDate, int type, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetFilter(int runType, DBConnection dbConnection);
        DataTable GetPRogramTargetReport(DBConnection dbConnection);

        DataTable GetPRogramTargetIndividualReport(DBConnection dbConnection);
    }

    public class ProgramTargetDAOImpl : ProgramTargetDAO
    {

        public int getMaxProgramTargetId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_TARGET";
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

        public int SaveProgramTarget(ProgramTarget programTarget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramTargetId(dbConnection);

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_TARGET(PROGRAM_TYPE_ID,PROGRAM_ID,TITLE,DESCRIPTION," +
                                            "START_DATE,END_DATE,OUTCOME,VOTE_NUMBER,NO_OF_PROJECTS,ESTIMATED_AMOUNT,TARGET_YEAR," +
                                            "TARGET_MONTH,OUTPUT,INSTRACTIONS,IS_RECOMMENDED,RECOMMENDED_BY,RECOMMENDED_DATE,Remarks,Created_By,Output_Description,Outcome_Description,Period_Type) " +

                                 "VALUES(@ProgramTypeId,@ProgramId,@Title,@Description,@StartDate,@EndDate,@Outcome,@VoteNumber,@NoOfProjects,@EstimatedAmount,@TargetYear,@TargetMonth,@Output,@Instractions,@IsRecommended,@RecommendedBy,@RecommendedDate,@Remarks,@CreatedBy,@Output_Description,@Outcome_Description,@Period_Type) SELECT SCOPE_IDENTITY() ";


            //dbConnection.cmd.Parameters.AddWithValue("@id", id);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeId", programTarget.ProgramTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramId", programTarget.ProgramId);
            dbConnection.cmd.Parameters.AddWithValue("@Title", programTarget.Title);
            dbConnection.cmd.Parameters.AddWithValue("@Description", programTarget.Description);
            dbConnection.cmd.Parameters.AddWithValue("@StartDate", programTarget.StartDate);
            dbConnection.cmd.Parameters.AddWithValue("@EndDate", programTarget.EndDate);
            dbConnection.cmd.Parameters.AddWithValue("@Outcome", programTarget.Outcome);
            dbConnection.cmd.Parameters.AddWithValue("@VoteNumber", programTarget.VoteNumber);
            dbConnection.cmd.Parameters.AddWithValue("@NoOfProjects", programTarget.NoOfProjects);
            dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programTarget.EstimatedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@TargetYear", programTarget.TargetYear);
            dbConnection.cmd.Parameters.AddWithValue("@TargetMonth", programTarget.TargetMonth);
            dbConnection.cmd.Parameters.AddWithValue("@Output", programTarget.Output);
            dbConnection.cmd.Parameters.AddWithValue("@Instractions", programTarget.Instractions);
            dbConnection.cmd.Parameters.AddWithValue("@IsRecommended", programTarget.IsRecommended);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", programTarget.RecommendedBy);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", programTarget.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", programTarget.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedBy", programTarget.CreatedBy);

            dbConnection.cmd.Parameters.AddWithValue("@Outcome_Description", programTarget.Outcome_Description);
            dbConnection.cmd.Parameters.AddWithValue("@Output_Description", programTarget.Output_Description);
            dbConnection.cmd.Parameters.AddWithValue("@Period_Type", programTarget.Period_Type);
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateProgramTarget(ProgramTarget programTarget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET PROGRAM_TYPE_ID =@ProgramTypeId , PROGRAM_ID = @ProgramId," +
                " TITLE = @Title, DESCRIPTION = @Description , START_DATE = @StartDate,END_DATE = @EndDate , OUTCOME = @Outcome , VOTE_NUMBER = @VoteNumber," +
                " NO_OF_PROJECTS = @NoOfProjects, ESTIMATED_AMOUNT = @EstimatedAmount, TARGET_YEAR = @TargetYear," +
                " TARGET_MONTH = @TargetMonth ,OUTPUT = @Output, INSTRACTIONS = @Instractions," +
                " IS_RECOMMENDED = @IsRecommended , RECOMMENDED_BY = @RecommendedBy, RECOMMENDED_DATE = @RecommendedDate,Remarks=@Remarks,Created_By=@CreatedBy WHERE ID = @ProgramTargetId";



            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programTarget.ProgramTargetId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeId", programTarget.ProgramTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramId", programTarget.ProgramId);
            dbConnection.cmd.Parameters.AddWithValue("@Title", programTarget.Title);
            dbConnection.cmd.Parameters.AddWithValue("@Description", programTarget.Description);
            dbConnection.cmd.Parameters.AddWithValue("@StartDate", programTarget.StartDate);
            dbConnection.cmd.Parameters.AddWithValue("@EndDate", programTarget.EndDate);
            dbConnection.cmd.Parameters.AddWithValue("@Outcome", programTarget.Outcome);
            dbConnection.cmd.Parameters.AddWithValue("@VoteNumber", programTarget.VoteNumber);
            dbConnection.cmd.Parameters.AddWithValue("@NoOfProjects", programTarget.NoOfProjects);
            dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programTarget.EstimatedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@TargetYear", programTarget.TargetYear);
            dbConnection.cmd.Parameters.AddWithValue("@TargetMonth", programTarget.TargetMonth);
            dbConnection.cmd.Parameters.AddWithValue("@Output", programTarget.Output);
            dbConnection.cmd.Parameters.AddWithValue("@Instractions", programTarget.Instractions);
            dbConnection.cmd.Parameters.AddWithValue("@IsRecommended", programTarget.IsRecommended);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", programTarget.RecommendedBy);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", programTarget.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Remarks", programTarget.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedBy", programTarget.CreatedBy);




            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int UpdateProgramTargetApproval(int id, int status, string reason, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET IS_RECOMMENDED = @Status,Reject_Remarks= @RejectReason WHERE ID=@Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", id);
            dbConnection.cmd.Parameters.AddWithValue("@Status", status);
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", reason);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }
        public int UpdateProgramTargetApprovalRecomended(int id, int recomendedby, int status, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET IS_RECOMMENDED = @IsRecomended," +
                "RECOMMENDED_BY=@RecomendedBy WHERE ID=@programTargetId";

            dbConnection.cmd.Parameters.AddWithValue("@IsRecomended", status);
            dbConnection.cmd.Parameters.AddWithValue("@RecomendedBy", recomendedby);
            dbConnection.cmd.Parameters.AddWithValue("@programTargetId", id);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public int UpdateIsView(int programTargetId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET Is_View =1 WHERE Id=" + programTargetId + "";

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramTarget> GetAllProgramTargetFilter(int runYear, int runMonth, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET  WHERE TARGET_YEAR = " + runYear + " AND TARGET_MONTH = " + runMonth + " ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }


        public List<ProgramTarget> UpcomingFilter(DateTime startDate, int type, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET  WHERE START_DATE = " + startDate + " AND PROGRAM_TYPE_ID = " + type + " ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

        public List<ProgramTarget> GetAllProgramTarget(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

        public ProgramTarget GetProgramTarget(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramTarget>(dbConnection.dr);

        }

        public List<ProgramTarget> GetAllProgramTargetByProgramId(int programId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_ID = " + programId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);
        }


        public List<ProgramTarget> GetAllProgramTargetByProgramTypeId(int ProgramtypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_TYPE_ID = " + ProgramtypeId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);
        }

        public List<ProgramTarget> GetAllProgramTargetFilter(int runType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_TYPE_ID  = " + runType + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

        public DataTable GetPRogramTargetReport(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT b.name, a.id AS Target_ID, c.Id AS Plan_ID, " +
                "b.Program_Type_Id, SUM(a.No_Of_Projects) AS Projects, " +
                "d.count, c.Male_Count+c.Female_Count AS No_of_Beneficiaries, j.Name AS Locations " +
                "FROM Program_Target a INNER JOIN Program b ON a.Program_Id = b.id " +
                "LEFT JOIN Program_Plan c ON a.id = c.Program_Target_Id " +
                "LEFT JOIN (SELECT Program_Target_Id, COUNT(Program_Target_Id) AS count " +
                "FROM Program_Plan where program_Plan.Project_Status_id =4 " +
                "GROUP BY Program_Target_Id) d ON a.id = d.Program_Target_Id " +
                "INNER JOIN (select Department_Unit_Possitions_Id, Program_Target_Id, Department_Unit_Id, " +
                "Name from program_Assignee f INNER JOIN Program_Target g ON g.Id = f.Program_Target_Id " +
                "INNER JOIN Department_Unit_Possitions h ON h.id = f.Department_Unit_Possitions_Id " +
                "INNER JOIN department_Unit i ON i.id = h.department_UNit_Id " +
                "group by Program_Target_Id, Department_Unit_Possitions_Id, Department_Unit_Id, name) j" +
                " ON j.program_target_id = c.Program_Target_Id where c.project_status_id = 4 " +
                "GROUP BY a.Program_Id, b.name, a.id, c.Id, b.Program_Type_Id, d.count, c.Male_Count, c.Female_Count, j.Name " +
                "order by Locations;";


            DataTable programTargetReport = new DataTable();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dbConnection.cmd);
            dataAdapter.Fill(programTargetReport);

            return programTargetReport;
        }

        public DataTable GetPRogramTargetIndividualReport(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT b.name, a.id AS Target_ID, c.Id AS Plan_ID, " +
                "b.Program_Type_Id, SUM(a.No_Of_Projects) AS Projects, d.count, " +
                "c.Male_Count+c.Female_Count AS No_of_Beneficiaries, j.Name AS Locations, j.Last_Name " +
                "FROM Program_Target a " +
                "INNER JOIN Program b ON a.Program_Id = b.id " +
                "LEFT JOIN Program_Plan c ON a.id = c.Program_Target_Id " +
                "LEFT JOIN(SELECT Program_Target_Id, COUNT(Program_Target_Id) AS count " +
                "FROM Program_Plan " +
                "where program_Plan.Project_Status_id = 4 GROUP BY Program_Target_Id) d ON a.id = d.Program_Target_Id " +
                "INNER JOIN(select Department_Unit_Possitions_Id, Program_Target_Id, " +
                "Department_Unit_Id, i.Name, m.Last_Name from program_Assignee f " +
                "INNER JOIN Program_Target g ON g.Id = f.Program_Target_Id " +
                "INNER JOIN Department_Unit_Possitions h ON h.id = f.Department_Unit_Possitions_Id " +
                "INNER JOIN department_Unit i ON i.id = h.department_UNit_Id " +
                "INNER JOIN Company_User k ON k.Id = h.System_User_Id " +
                "INNER JOIN Employee m ON m.ID = k.Emp_Number " +
                "group by Program_Target_Id, Department_Unit_Possitions_Id, Department_Unit_Id, i.name, m.Last_Name)" +
                " j ON j.program_target_id = c.Program_Target_Id where c.project_status_id = 4 " +
                "GROUP BY a.Program_Id, b.name, a.id, c.Id, b.Program_Type_Id, d.count, c.Male_Count, c.Female_Count, j.Name,j.Last_Name " +
                "order by j.Last_Name;";


            DataTable programIndividualTargetReport = new DataTable();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dbConnection.cmd);
            dataAdapter.Fill(programIndividualTargetReport);

            return programIndividualTargetReport;
        }

    }
}
