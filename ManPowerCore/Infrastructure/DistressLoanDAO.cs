using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DistressLoanDAO
    {
        int Save(DistressLoan distressLoan, DBConnection dbConnection);

        int Update(DistressLoan distressLoan, DBConnection dbConnection);

        int UpdatetoAdmin(DistressLoan distressLoan, DBConnection dbConnection);

        List<DistressLoan> GetAllDistressLoan(DBConnection dbConnection);
    }

    public class DistressLoanDAOSqlImpl : DistressLoanDAO
    {
        public int Save(DistressLoan distressLoan, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Distress_Loan (Loan_Details_Id, Reason_For_Loan,  Last_Loan_Date, Salary_Slip) " +
                                "VALUES (@LoanDetailsId, @ReasonForLoan,@LastLoanDate, @SalarySlip) SELECT SCOPE_IDENTITY()";

            dbConnection.cmd.Parameters.AddWithValue("@LoanDetailsId", distressLoan.LoanDetailsId);
            dbConnection.cmd.Parameters.AddWithValue("@ReasonForLoan", distressLoan.ReasonForLoan);
            //dbConnection.cmd.Parameters.AddWithValue("@LastLoanBalance", distressLoan.LastLoanBalance);
            //dbConnection.cmd.Parameters.AddWithValue("@IsProbation", distressLoan.IsProbation);
            //dbConnection.cmd.Parameters.AddWithValue("@PossibilityToPermanent", distressLoan.PossibilityToPermanent);
            //dbConnection.cmd.Parameters.AddWithValue("@IsPermanent", distressLoan.IsPermanent);
            //dbConnection.cmd.Parameters.AddWithValue("@RetireDate", distressLoan.RetireDate);
            //dbConnection.cmd.Parameters.AddWithValue("@MonthlyConsolidatedSalary", distressLoan.MonthlyConsolidatedSalary);
            //dbConnection.cmd.Parameters.AddWithValue("@IsSuspend", distressLoan.IsSuspend);
            //dbConnection.cmd.Parameters.AddWithValue("@LastLoanType", distressLoan.LastLoanType);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", distressLoan.LastLoanDate);
            //dbConnection.cmd.Parameters.AddWithValue("@LastLoanAmount", distressLoan.LastLoanAmount);
            //dbConnection.cmd.Parameters.AddWithValue("@FourtyOfSalary", distressLoan.FourtyOfSalary);
            //dbConnection.cmd.Parameters.AddWithValue("@PayableAmount", distressLoan.PayableAmount);
            //dbConnection.cmd.Parameters.AddWithValue("@DistressLoanBalance", distressLoan.DistressLoanBalance);
            //dbConnection.cmd.Parameters.AddWithValue("@PeriodicalAmount", distressLoan.PeriodicalAmount);
            //dbConnection.cmd.Parameters.AddWithValue("@NoOfPeriods", distressLoan.NoOfPeriods);
            //dbConnection.cmd.Parameters.AddWithValue("@GuarantorApprove", distressLoan.GuarantorApprove);
            dbConnection.cmd.Parameters.AddWithValue("@SalarySlip", distressLoan.SalarySlip);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(DistressLoan distressLoan, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Distress_Loan " +
                                "SET " +
                                //"Reason_For_Loan = @ReasonForLoan, " +
                                "Last_Loan_Balance = @LastLoanBalance, " +
                                //"Is_Probation = @IsProbation, " +
                                //"Possibility_To_Permanent = @PossibilityToPermanent, " +
                                //"Is_Permanent = @IsPermanent, " +
                                //"Retire_Date = @RetireDate, " +
                                //"Monthly_Consolidated_salary = @MonthlyConsolidatedSalary, " +
                                //"Is_Suspend = @IsSuspend, " +
                                "Last_Loan_Type = @LastLoanType, " +
                                "Last_Loan_Date = @LastLoanDate, " +
                                "Last_Loan_Amount = @LastLoanAmount, " +
                                "Fourty_Of_Salary = @FourtyOfSalary, " +
                                "Payable_Amount = @PayableAmount, " +
                                "Distress_Loan_Balance = @DistressLoanBalance, " +
                                "Periodical_Amount = @PeriodicalAmount, " +
                                "No_Of_Periods = @NoOfPeriods, " +
                                "Guarantor_Approve = @GuarantorApprove " +
                                //"Loan_Details_Id=@LoanDetailId" +
                                "WHERE Id = @LoanDetailId";


            //dbConnection.cmd.Parameters.AddWithValue("@ReasonForLoan", distressLoan.ReasonForLoan);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanBalance", distressLoan.LastLoanBalance);
            //dbConnection.cmd.Parameters.AddWithValue("@IsProbation", distressLoan.IsProbation);
            //dbConnection.cmd.Parameters.AddWithValue("@PossibilityToPermanent", distressLoan.PossibilityToPermanent);
            //dbConnection.cmd.Parameters.AddWithValue("@IsPermanent", distressLoan.IsPermanent);
            //dbConnection.cmd.Parameters.AddWithValue("@RetireDate", distressLoan.RetireDate);
            //dbConnection.cmd.Parameters.AddWithValue("@MonthlyConsolidatedSalary", distressLoan.MonthlyConsolidatedSalary);
            //dbConnection.cmd.Parameters.AddWithValue("@IsSuspend", distressLoan.IsSuspend);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanType", distressLoan.LastLoanType);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanDate", distressLoan.LastLoanDate);
            dbConnection.cmd.Parameters.AddWithValue("@LastLoanAmount", distressLoan.LastLoanAmount);
            dbConnection.cmd.Parameters.AddWithValue("@FourtyOfSalary", distressLoan.FourtyOfSalary);
            dbConnection.cmd.Parameters.AddWithValue("@PayableAmount", distressLoan.PayableAmount);
            dbConnection.cmd.Parameters.AddWithValue("@DistressLoanBalance", distressLoan.DistressLoanBalance);
            dbConnection.cmd.Parameters.AddWithValue("@PeriodicalAmount", distressLoan.PeriodicalAmount);
            dbConnection.cmd.Parameters.AddWithValue("@NoOfPeriods", distressLoan.NoOfPeriods);
            dbConnection.cmd.Parameters.AddWithValue("@GuarantorApprove", distressLoan.GuarantorApprove);
            //dbConnection.cmd.Parameters.AddWithValue("@DistressLoanId", distressLoan.DistressLoanId);
            dbConnection.cmd.Parameters.AddWithValue("@LoanDetailId", distressLoan.LoanDetailsId);



            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int UpdatetoAdmin(DistressLoan distressLoan, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Distress_Loan " +
                                "SET " +
                                "Is_Probation = @IsProbation, " +
                                "Possibility_To_Permanent = @PossibilityToPermanent, " +
                                "Is_Permanent = @IsPermanent, " +
                                "Retire_Date = @RetireDate, " +
                                "Monthly_Consolidated_salary = @MonthlyConsolidatedSalary, " +
                                "Is_Suspend = @IsSuspend " +
                                "WHERE Id = @DistressLoanId";



            dbConnection.cmd.Parameters.AddWithValue("@IsProbation", distressLoan.IsProbation);
            dbConnection.cmd.Parameters.AddWithValue("@PossibilityToPermanent", distressLoan.PossibilityToPermanent);
            dbConnection.cmd.Parameters.AddWithValue("@IsPermanent", distressLoan.IsPermanent);
            dbConnection.cmd.Parameters.AddWithValue("@RetireDate", distressLoan.RetireDate);
            dbConnection.cmd.Parameters.AddWithValue("@MonthlyConsolidatedSalary", distressLoan.MonthlyConsolidatedSalary);
            dbConnection.cmd.Parameters.AddWithValue("@IsSuspend", distressLoan.IsSuspend);
            dbConnection.cmd.Parameters.AddWithValue("@DistressLoanId", distressLoan.DistressLoanId);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<DistressLoan> GetAllDistressLoan(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Distress_Loan";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DistressLoan>(dbConnection.dr);
        }
    }
}
