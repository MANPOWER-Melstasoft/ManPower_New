using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    }

    public class LoanDetailDAOSqlImpl : LoanDetailDAO
    {
        public int Save(LoanDetail loanDetails, DBConnection dbConnection)
        {

            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Loan_Details (Employee_ID, Approval_Status_Id, Loan_Type_Id, Full_Name, Position, Work_Place, Work_Type, Appointed_Date, Basic_Salary, Loan_Amount, Loan_Require_Date, Created_Date) " +
                                "VALUES (@EmployeeId, @ApprovalStatusId, @LoanTypeId, @FullName, @Position, @WorkPlace, @WorkType, @AppointedDate, @BasicSalary, @LoanAmount, @LoanRequireDate, @CreatedDate)";

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

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
            return output;
        }

        public int Update(LoanDetail loanDetails, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Loan_Details " +
                                "SET Payment_Voucher_Id = @PaymentVoucherId, Employee_ID = @EmployeeId, " +
                                "Approval_Status_Id = @ApprovalStatusId, Loan_Type_Id = @LoanTypeId, " +
                                "Full_Name = @FullName, Position = @Position, Work_Place = @WorkPlace, " +
                                "Work_Type = @WorkType, Appointed_Date = @AppointedDate, " +
                                "Basic_Salary = @BasicSalary, Loan_Amount = @LoanAmount, " +
                                "Loan_Require_Date = @LoanRequireDate, Created_Date = @CreatedDate, " +
                                "Salary_No = @SalaryNo, Last_Loan_Date = @LastLoanDate, " +
                                "Last_Loan_Paid_Month = @LastLoanPaidMonth, Reject_Reason = @RejectReason, " +
                                "Approval_Date = @ApprovalDate, Head_Approval_Date = @HeadApprovalDate, " +
                                "WHERE Id = @LoanDetailsId";

            dbConnection.cmd.Parameters.AddWithValue("@PaymentVoucherId", loanDetails.PaymentVoucherId);
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
            dbConnection.cmd.Parameters.AddWithValue("@SalaryNo", loanDetails.SalaryNo);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", loanDetails.LastLoanDate);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanPaidMonth", loanDetails.LastLoanPaidMonth);
            dbConnection.cmd.Parameters.AddWithValue("@RejectReason", loanDetails.RejectReason);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalDate", loanDetails.ApprovalDate);
            dbConnection.cmd.Parameters.AddWithValue("@HeadApprovalDate", loanDetails.HeadApprovalDate);
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

    }
}
