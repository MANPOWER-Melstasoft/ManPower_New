using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramPlanDAO
    {

        List<ProgramPlan> GetAllProgramPlan(DBConnection dbConnection);
        ProgramPlan GetProgramPlan(int id, DBConnection dbConnection);
        int SaveProgramPlan(ProgramPlan programPlan, DBConnection dbConnection);
        int UpdateProgramPlan(ProgramPlan programPlan, DBConnection dbConnection);

        int UpdateProgramPlanComplete(int statusId, int id, DBConnection dbConnection);

        List<ProgramPlan> GetAllProgramPlanByProgramTargetId(int programTargetId, DBConnection dBConnection);
        List<ProgramPlan> GetAllProgramPlanByProgramCategoryId(int programCategoryId, DBConnection dbConnection);
        List<ProgramPlan> GetAllProgramPlanByProjectStatusId(int projectStatusId, DBConnection dbConnection);
        List<ProgramPlan> GetAllProgramPlanByDateTypeDistrict(string date, int programType, int districtId, DBConnection dbConnection);

        List<ProgramPlan> getddlProgramPlan(int depId, int year, DBConnection dBConnection);

        DataTable getProgramPlan(int DepID, DBConnection dbConnection);
    }

    public class ProgramPlanDAOImpl : ProgramPlanDAO
    {

        public int getMaxProgramPlanId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_PLAN";
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

        public int SaveProgramPlan(ProgramPlan programPlan, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            //int id = getMaxProgramPlanId(dbConnection);

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_PLAN(PROJECT_STATUS_ID,PROGRAM_CATEGORY_ID,PROGRAM_TARGET_ID,DATE," +
                                            "LOCATION,OUTCOME,OUTPUT,ACTUAL_OUTPUT,IS_APPROVED,APPROVED_BY,APPROVED_DATE," +
                                            "TOTAL_ESTIMATED_AMOUNT,APPROVED_AMOUNT,ACTUAL_AMOUNT,MALE_COUNT,FEMALE_COUNT) " +

                                 "VALUES(@ProjectStatusId,@ProgramCategoryId,@ProgramTargetId,@Date,@Location,@Outcome," +
                                 "@Output,@ActualOutput,@IsApproved,@ApprovedBy,@ApprovedDate,@TotalEstimatedAmount," +
                                 "@ApprovedAmount,@ActualAmount,@MaleCount,@FemaleCount) ";




            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", programPlan.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryId", programPlan.ProgramCategoryId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programPlan.ProgramTargetId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", programPlan.Date);
            dbConnection.cmd.Parameters.AddWithValue("@Location", programPlan.Location);
            dbConnection.cmd.Parameters.AddWithValue("@Outcome", programPlan.Outcome);
            dbConnection.cmd.Parameters.AddWithValue("@Output", programPlan.Output);
            dbConnection.cmd.Parameters.AddWithValue("@ActualOutput", programPlan.ActualOutput);
            dbConnection.cmd.Parameters.AddWithValue("@IsApproved", programPlan.IsApproved);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", programPlan.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", programPlan.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@TotalEstimatedAmount", programPlan.TotalEstimatedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedAmount", programPlan.ApprovedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ActualAmount", programPlan.ActualAmount);
            dbConnection.cmd.Parameters.AddWithValue("@MaleCount", programPlan.MaleCount);
            dbConnection.cmd.Parameters.AddWithValue("@FemaleCount", programPlan.FemaleCount);







            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramPlan(ProgramPlan programPlan, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_PLAN SET PROJECT_STATUS_ID = @ProjectStatusId ," +
            " PROGRAM_CATEGORY_ID = @ProgramCategoryId," +
            " DATE = @Date, LOCATION = @Location,OUTCOME = @Outcome , OUTPUT = @Output ," +
            " ACTUAL_OUTPUT = @ActualOutput, IS_APPROVED = @IsApproved, APPROVED_BY =@ApprovedBy ," +
            " APPROVED_DATE = @ApprovedDate ,TOTAL_ESTIMATED_AMOUNT = @TotalEstimatedAmount,APPROVED_AMOUNT = @ApprovedAmount," +
            " ACTUAL_AMOUNT = @ActualAmount, MALE_COUNT = @MaleCount ," +
            " FEMALE_COUNT = @FemaleCount,Financial_Source=@FinancialResource,ProgramName=@programName,CoordinaterOfficer=@cordinateOfficer WHERE ID = @ProgramPlanId ";




            dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programPlan.ProgramPlanId);
            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", programPlan.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryId", programPlan.ProgramCategoryId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programPlan.ProgramTargetId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", programPlan.Date);
            dbConnection.cmd.Parameters.AddWithValue("@Location", programPlan.Location);
            dbConnection.cmd.Parameters.AddWithValue("@Outcome", programPlan.Outcome);
            dbConnection.cmd.Parameters.AddWithValue("@Output", programPlan.Output);
            dbConnection.cmd.Parameters.AddWithValue("@ActualOutput", programPlan.ActualOutput);
            dbConnection.cmd.Parameters.AddWithValue("@IsApproved", programPlan.IsApproved);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", programPlan.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", programPlan.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@TotalEstimatedAmount", programPlan.TotalEstimatedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedAmount", programPlan.ApprovedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ActualAmount", programPlan.ActualAmount);
            dbConnection.cmd.Parameters.AddWithValue("@MaleCount", programPlan.MaleCount);
            dbConnection.cmd.Parameters.AddWithValue("@FemaleCount", programPlan.FemaleCount);
            dbConnection.cmd.Parameters.AddWithValue("@programName", programPlan.ProgramName);
            dbConnection.cmd.Parameters.AddWithValue("@cordinateOfficer", programPlan.Coordinater);
            dbConnection.cmd.Parameters.AddWithValue("@FinancialResource", programPlan.FinancialSource);



            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramPlanComplete(int statusId, int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_PLAN SET PROJECT_STATUS_ID = " + statusId + "WHERE ID = " + id + " ";

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramPlan> GetAllProgramPlan(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);

        }

        public ProgramPlan GetProgramPlan(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramPlan>(dbConnection.dr);

        }

        public List<ProgramPlan> GetAllProgramPlanByProgramTargetId(int programTargetId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN WHERE PROGRAM_TARGET_ID = " + programTargetId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);
        }

        public List<ProgramPlan> GetAllProgramPlanByProgramCategoryId(int programCategoryId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN WHERE PROGRAM_CATEGORY_ID = " + programCategoryId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);
        }


        public List<ProgramPlan> GetAllProgramPlanByProjectStatusId(int projectStatusId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN WHERE PROJECT_STATUS_ID = " + projectStatusId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);
        }

        public List<ProgramPlan> GetAllProgramPlanByDateTypeDistrict(string date, int programType, int districtId, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            string dateSql = "";
            if (date != null)
                dateSql = " AND pp.Date = '" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' ";

            string programTypeSql = "";
            if (programType != 0)
                programTypeSql = " AND pt.Program_Type_Id = " + programType + " ";

            string districtIdSql = "";
            if (districtId != 0)
                districtIdSql = " AND du.Parent_Id = " + districtId + " ";

            dbConnection.cmd.CommandText = "select pp.* from Program_Plan pp " +
                                            "inner join Program_Target pt on pt.Id = pp.Program_Target_Id " +
                                            "inner join Program_Assignee pa on pa.Program_Target_Id = pt.Id " +
                                            "inner join Department_Unit_Possitions dup on dup.Id = pa.Department_Unit_Possitions_Id " +
                                            "inner join Department_Unit du on du.Id = dup.Department_Unit_Id " +
                                            "WHERE pp.PROJECT_STATUS_ID = 4" + dateSql + programTypeSql + districtIdSql;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);
        }

        public List<ProgramPlan> getddlProgramPlan(int depId, int year, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "select * from Program_Plan inner join Program_Target on" +
                                 " Program_Plan.Program_Target_Id = Program_Target.id inner join Program_Assignee on" +
                                 " Program_Plan.Program_Target_Id = Program_Assignee.Program_Target_Id " +
                                 "where Program_Assignee.Department_Unit_Possitions_Id =" + depId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);
        }

        public DataTable getProgramPlan(int DepId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            DataTable programPlanList = new DataTable();

            dbConnection.cmd.CommandText = "select e.Name AS Program_Name, x.Id, a.Location,a.Date,a.Approved_Amount, x.Program_Id ," +
                "sum(x.an) as annual_Count, sum(x.qt) as quartly_Count,sum(x.ml) as monthly_Count," +
                "a.Male_Count, a.Female_Count , a.Male_Count + a.Female_Count as total_count, " +
                "x.Vote_Number,a.Financial_Source, g.Person, g.Work_Places " +
                "from(" +
                "select b.Id, b.Program_Id, b.No_Of_Projects, b.Vote_Number, b.Period_Type as an, 0 as qt, 0 as ml from Program_Target b " +
                "INNER JOIN Program_Assignee c ON c.Program_Target_Id = b.Id " +
                "WHERE c.Department_Unit_Possitions_Id = " + DepId + " and b.Period_Type = 1 " +
                "union all " +
                "select b.Id, b.Program_Id, 0 as an, b.No_Of_Projects, b.Vote_Number, b.Period_Type as qt, 0 as ml from Program_Target b " +
                "INNER JOIN Program_Assignee c ON c.Program_Target_Id = b.Id " +
                "WHERE c.Department_Unit_Possitions_Id = " + DepId + " and b.Period_Type = 2 " +
                "union all " +
                "select b.Id, b.Program_Id, 0 as an, 0 as qt, b.No_Of_Projects, b.Vote_Number, b.Period_Type as ml from Program_Target b " +
                "INNER JOIN Program_Assignee c ON c.Program_Target_Id = b.Id " +
                "WHERE c.Department_Unit_Possitions_Id = " + DepId + " and b.Period_Type = 3) x " +
                "inner join Program_Plan a on  a.Program_Target_Id = x.Id " +
                "INNER JOIN Program e ON e.id = x.program_id " +
                "LEFT JOIN Resource_Person_Program_Plan f ON f.Program_Plan_Id = a.Id " +
                "LEFT JOIN (select Program_plan_id, string_agg(Name, ',') as Person,string_agg(Work_Place, ',') as Work_Places " +
                "from resource_person_program_plan LEFT JOIN Resource_Person g ON " +
                "Resource_Person_Program_Plan.Resourse_Person_Id = g.id group by Program_plan_id) g ON f.Program_Plan_Id = g.Program_Plan_Id " +
                "LEFT JOIN Job_Refferals h ON h.Program_Plan_Id = a.Id " +
                "LEFT JOIN Training_Refferals i ON i.Program_Plan_Id = a.Id " +
                "LEFT JOIN Career_Key_Test_Results k ON k.Program_Plan_Id = a.Id " +
                "group by x.Program_Id,x.Id ,e.Name,a.Location,a.Date,a.Approved_Amount,a.Male_Count,a.Female_Count," +
                "x.Vote_Number,a.Financial_Source, g.Person, g.Work_Places;";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dbConnection.cmd);
            dataAdapter.Fill(programPlanList);


            return programPlanList;
        }
    }
}



