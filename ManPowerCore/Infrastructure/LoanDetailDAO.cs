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
    public interface LoanDetailDAO
    {
        int Save(LoanDetail loanDetail, DBConnection dbConnection);

        int Update(LoanDetail loanDetail, DBConnection dbConnection);
        int UpdateStatus(int id, int approvalstatusId, DBConnection dbConnection);

        List<LoanDetail> GetAllLoanDetail(DBConnection dbConnection);

        DataTable GetLoanReport(DBConnection dbConnection);
    }

    public class LoanDetailDAOSqlImpl : LoanDetailDAO
    {
        public int Save(LoanDetail loanDetails, DBConnection dbConnection)
        {

            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Loan_Details (Employee_ID, Approval_Status_Id, Loan_Type_Id, Full_Name, Position, Work_Place, Work_Type, Appointed_Date, Basic_Salary, Loan_Amount, Loan_Require_Date, Created_Date) " +
                                "VALUES (@EmployeeId, @ApprovalStatusId, @LoanTypeId, @FullName, @Position, @WorkPlace, @WorkType, @AppointedDate, @BasicSalary, @LoanAmount, @LoanRequireDate, @CreatedDate) SELECT SCOPE_IDENTITY()";

            //dbConnection.cmd.Parameters.AddWithValue("@PaymentVoucherId", loanDetails.PaymentVoucherId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", loanDetails.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalStatusId", loanDetails.ApprovalStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@LoanTypeId", loanDetails.LoanTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@FullName", loanDetails.FullName);
            dbConnection.cmd.Parameters.AddWithValue("@Position", loanDetails.Position);
            dbConnection.cmd.Parameters.AddWithValue("@WorkPlace", loanDetails.WorkPlace);
            dbConnection.cmd.Parameters.AddWithValue("@WorkType", loanDetails.WorkType);
            dbConnection.cmd.Parameters.AddWithValue("@AppointedDate", loanDetails.AppointedDate);
            dbConnection.cmd.Parameters.AddWithValue("@BasicSalary", loanDetails.BasicSalary);
            dbConnection.cmd.Parameters.AddWithValue("@LoanAmount", loanDetails.LoanAmount);
            dbConnection.cmd.Parameters.AddWithValue("@LoanRequireDate", loanDetails.LoanRequireDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", loanDetails.CreatedDate);
            //dbConnection.cmd.Parameters.AddWithValue("@SalaryNo", loanDetails.SalaryNo);
            //dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", loanDetails.LastLoanDate);
            //dbConnection.cmd.Parameters.AddWithValue("@LastLoanPaidMonth", loanDetails.LastLoanPaidMonth);
            //dbConnection.cmd.Parameters.AddWithValue("@RejectReason", loanDetails.RejectReason);
            //dbConnection.cmd.Parameters.AddWithValue("@ApprovalDate", loanDetails.ApprovalDate);
            //dbConnection.cmd.Parameters.AddWithValue("@HeadApprovalDate", loanDetails.HeadApprovalDate);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            return output;
        }

        public int Update(LoanDetail loanDetails, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Loan_Details " +
                                "SET " +
                                //"Employee_ID = @EmployeeId, " +
                                "Approval_Status_Id = @ApprovalStatusId," +
                                //" Loan_Type_Id = @LoanTypeId, " +
                                //"Full_Name = @FullName, Position = @Position, Work_Place = @WorkPlace, " +
                                //"Work_Type = @WorkType, Appointed_Date = @AppointedDate, " +
                                //"Basic_Salary = @BasicSalary, Loan_Amount = @LoanAmount, " +
                                //"Loan_Require_Date = @LoanRequireDate, Created_Date = @CreatedDate, " +
                                //"Salary_No = @SalaryNo, " +
                                "Last_Loan_Date = @LastLoanDate, " +
                                "Last_Loan_Paid_Month = @LastLoanPaidMonth " +
                                "WHERE Id = @LoanDetailsId";

            //dbConnection.cmd.Parameters.AddWithValue("@PaymentVoucherId", loanDetails.PaymentVoucherId);
            //dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", loanDetails.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalStatusId", loanDetails.ApprovalStatusId);
            //dbConnection.cmd.Parameters.AddWithValue("@LoanTypeId", loanDetails.LoanTypeId);
            //dbConnection.cmd.Parameters.AddWithValue("@FullName", loanDetails.FullName);
            //dbConnection.cmd.Parameters.AddWithValue("@Position", loanDetails.Position);
            //dbConnection.cmd.Parameters.AddWithValue("@WorkPlace", loanDetails.WorkPlace);
            //dbConnection.cmd.Parameters.AddWithValue("@WorkType", loanDetails.WorkType);
            //dbConnection.cmd.Parameters.AddWithValue("@AppointedDate", loanDetails.AppointedDate);
            //dbConnection.cmd.Parameters.AddWithValue("@BasicSalary", loanDetails.BasicSalary);
            //dbConnection.cmd.Parameters.AddWithValue("@LoanAmount", loanDetails.LoanAmount);
            //dbConnection.cmd.Parameters.AddWithValue("@LoanRequireDate", loanDetails.LoanRequireDate);
            //dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", loanDetails.CreatedDate);
            //dbConnection.cmd.Parameters.AddWithValue("@SalaryNo", loanDetails.SalaryNo);
            if (loanDetails.LastLoanDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", SqlDateTime.Null);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", loanDetails.LastLoanDate);

            }

            if (loanDetails.LastLoanPaidMonth.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@LastLoanPaidMonth", SqlDateTime.Null);

            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@LastLoanPaidMonth", loanDetails.LastLoanPaidMonth);

            }
            dbConnection.cmd.Parameters.AddWithValue("@LoanDetailsId", loanDetails.LoanDetailsId);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
            return output;
        }

        public List<LoanDetail> GetAllLoanDetail(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Loan_Details";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<LoanDetail>(dbConnection.dr);
        }


        public int UpdateStatus(int id, int approvalstatusId, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Loan_Details SET  Approval_Status_Id= " + approvalstatusId + " WHERE Id=" + id + " ";


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
            return output;
        }

        public DataTable GetLoanReport(DBConnection dbConnection)
        {
            DataTable LoanReportTable = new DataTable();

            dbConnection.cmd.CommandText = "select b.id, a.Full_Name, a.Created_Date, a.Loan_Amount, a.loan_type_id, " +
                "a.Position, du.Name As District, du2.Name As DSDivision,  c.Approve_Date, lt.Loan_Type_Name " +
                "from Loan_Details a inner join employee b ON b.id = a.Employee_ID " +
                "inner join approval_history c on c.loan_details_id = a.id " +
                "left join Loan_Type lt On lt.Id = a.Loan_Type_Id " +
                "left join Department_Unit du on du.Id = b.District_Id " +
                "left join Department_Unit du2 on du2.Id = b.DSDivision_Id " +
                "where c.Approval_Status_Id = 8;";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dbConnection.cmd);
            dataAdapter.Fill(LoanReportTable);


            return LoanReportTable;
        }

    }
}
