using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface LoanTypeDAO
    {
        int Save(LoanType loanType, DBConnection dbConnection);

        int Update(LoanType loanType, DBConnection dbConnection);

        List<LoanType> GetAllLoanType(DBConnection dbConnection);

    }

    public class LoanTypeDAOSqlImpl : LoanTypeDAO
    {
        public int Save(LoanType loanType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Loan_Type_Name (Loan_Type_Name) VALUES (@LoanType)";

            dbConnection.cmd.Parameters.AddWithValue("@LoanType", loanType.Loan_Type_Name);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(LoanType loanType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Loan_Type SET Loan_Type_Name = @LoanType WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@LoanType", loanType.Loan_Type_Name);
            dbConnection.cmd.Parameters.AddWithValue("@Id", loanType.Id);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<LoanType> GetAllLoanType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Loan_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<LoanType>(dbConnection.dr);
        }
    }
}
