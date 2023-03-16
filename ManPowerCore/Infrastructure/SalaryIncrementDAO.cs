using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface SalaryIncrementDAO
    {
        int Save(SalaryIncrement salaryIncrement, DBConnection dbConnection);

        int Update(SalaryIncrement salaryIncrement, DBConnection dbConnection);

        List<SalaryIncrement> GetAllSalaryIncrement(DBConnection dbConnection);
    }

    public class SalaryIncrementDAOSqlImpl : SalaryIncrementDAO
    {
        public int Save(SalaryIncrement salaryIncrement, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Salary_Increment (Employee_ID, Salary_Increment_Status_Id, Created_User, Created_Date, Basic_Salary, Allowances, Total_Salary) " +
                                "VALUES (@EmployeeId, @SalaryIncrementStatusId, @CreatedUser, @CreatedDate, @BasicSalary, @Allowances, @TotalSalary)";

            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", salaryIncrement.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@SalaryIncrementStatusId", salaryIncrement.SalaryIncrementStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", salaryIncrement.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", salaryIncrement.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@BasicSalary", salaryIncrement.BasicSalary);
            dbConnection.cmd.Parameters.AddWithValue("@Allowances", salaryIncrement.Allowances);
            dbConnection.cmd.Parameters.AddWithValue("@TotalSalary", salaryIncrement.TotalSalary);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(SalaryIncrement salaryIncrement, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Salary_Increment SET Employee_ID = @EmployeeId, Salary_Increment_Status_Id = @SalaryIncrementStatusId, Created_User = @CreatedUser, " +
                                "Created_Date = @CreatedDate, Basic_Salary = @BasicSalary, Allowances = @Allowances, Total_Salary = @TotalSalary WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", salaryIncrement.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@SalaryIncrementStatusId", salaryIncrement.SalaryIncrementStatusId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", salaryIncrement.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", salaryIncrement.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@BasicSalary", salaryIncrement.BasicSalary);
            dbConnection.cmd.Parameters.AddWithValue("@Allowances", salaryIncrement.Allowances);
            dbConnection.cmd.Parameters.AddWithValue("@TotalSalary", salaryIncrement.TotalSalary);
            dbConnection.cmd.Parameters.AddWithValue("@Id", salaryIncrement.Id);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<SalaryIncrement> GetAllSalaryIncrement(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Salary_Increment";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SalaryIncrement>(dbConnection.dr);
        }
    }
}
