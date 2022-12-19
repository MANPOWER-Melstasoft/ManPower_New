using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramPlanDAO
    {

        List<ProgramPlan> GetAllProgramPlan(DBConnection dbConnection);
        ProgramPlan GetProgramPlan(int id, DBConnection dbConnection);
        int SaveProgramPlan(ProgramPlan programPlan, DBConnection dbConnection);
        int UpdateProgramPlan(ProgramPlan programPlan, DBConnection dbConnection);

        List<ProgramPlan> GetAllProgramPlanByProgramTargetId(int programTargetId, DBConnection dBConnection);
        List<ProgramPlan> GetAllProgramPlanByProgramCategoryId(int programCategoryId, DBConnection dbConnection);
        List<ProgramPlan> GetAllProgramPlanByProjectStatusId(int projectStatusId, DBConnection dbConnection);

        List<ProgramPlan> completedProgramsFiter(DateTime startDate, DBConnection dbConnection);
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

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_PLAN(PROJECT_STATUS_ID,PROGRAM_CATEGORY_ID,PROGRAM_TARGET_ID,DATE," +
                                            "LOCATION,OUTCOME,OUTPUT,ACTUAL_OUTPUT,IS_APPROVED,APPROVED_BY,APPROVED_DATE," +
                                            "TOTAL_ESTIMATED_AMOUNT,APPROVED_AMOUNT,ACTUAL_AMOUNT,MALE_COUNT,FEMALE_COUNT, REMARK, PROGRAMNAME,COORDINATEROFFICER, FINANCIAL_SOURCE) " +

                                 "VALUES(@ProjectStatusId,@ProgramCategoryId,@ProgramTargetId,@ConductDate,@ConductLocation,@ProgramOutcome," +
                                 "@ProgramOutput,@ActualOutput,@IsApproved,@ApprovedBy,@ApprovedDate,@TotalEstimatedAmount," +
                                 "@ApprovedAmount,@ActualAmount,@MaleCount,@FemaleCount,@ProgramRemark,@Name,@Coordinater,@FinancialSource) ";




            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", programPlan.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryId", programPlan.ProgramCategoryId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programPlan.ProgramTargetId);
            dbConnection.cmd.Parameters.AddWithValue("@ConductDate", programPlan.ConductDate);
            dbConnection.cmd.Parameters.AddWithValue("@ConductLocation", programPlan.ConductLocation);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramOutcome", programPlan.ProgramOutcome);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramOutput", programPlan.ProgramOutput);
            dbConnection.cmd.Parameters.AddWithValue("@ActualOutput", programPlan.ActualOutput);
            dbConnection.cmd.Parameters.AddWithValue("@IsApproved", programPlan.IsApproved);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", programPlan.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", programPlan.ApprovedDate);
            dbConnection.cmd.Parameters.AddWithValue("@TotalEstimatedAmount", programPlan.TotalEstimatedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedAmount", programPlan.ApprovedAmount);
            dbConnection.cmd.Parameters.AddWithValue("@ActualAmount", programPlan.ActualAmount);
            dbConnection.cmd.Parameters.AddWithValue("@MaleCount", programPlan.MaleCount);
            dbConnection.cmd.Parameters.AddWithValue("@FemaleCount", programPlan.FemaleCount);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramRemark", programPlan.ProgramRemark);
            dbConnection.cmd.Parameters.AddWithValue("@Name", programPlan.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Coordinater", programPlan.Coordinater);
            dbConnection.cmd.Parameters.AddWithValue("@FinancialSource", programPlan.FinancialSource);


            dbConnection.cmd.ExecuteNonQuery();


            return 1;
        }

        public int UpdateProgramPlan(ProgramPlan programPlan, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_PLAN SET PROJECT_STATUS_ID = @ProjectStatusId ," +
            " PROGRAM_CATEGORY_ID = @ProgramCategoryId, PROGRAM_TARGET_ID = @ProgramTargetId," +
            " DATE = @Date, LOCATION = @Location,OUTCOME = @Outcome , OUTPUT = @Output ," +
            " ACTUAL_OUTPUT = @ActualOutput, IS_APPROVED = @IsApproved, APPROVED_BY =@ApprovedBy ," +
            " APPROVED_DATE = @ApprovedDate ,TOTAL_ESTIMATED_AMOUNT = @TotalEstimatedAmount,APPROVED_AMOUNT = @ApprovedAmount," +
            " ACTUAL_AMOUNT = @ActualAmount, MALE_COUNT = @MaleCount ," +
            " FEMALE_COUNT = @FemaleCount WHERE ID = @ProgramPlanId ";




            dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programPlan.ProgramPlanId);
            dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", programPlan.ProjectStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryId", programPlan.ProgramCategoryId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programPlan.ProgramTargetId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", programPlan.ConductDate);
            dbConnection.cmd.Parameters.AddWithValue("@Location", programPlan.ConductLocation);
            dbConnection.cmd.Parameters.AddWithValue("@Outcome", programPlan.ProgramOutcome);
            dbConnection.cmd.Parameters.AddWithValue("@Output", programPlan.ProgramOutput);
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

        public List<ProgramPlan> GetAllProgramPlan(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN ORDER BY ID ";

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

        public List<ProgramPlan> completedProgramsFiter(DateTime startDate, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_PLAN WHERE DATE = " + startDate + "  ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramPlan>(dbConnection.dr);

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

    }



}
