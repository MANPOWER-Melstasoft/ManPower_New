using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface SalaryIncrementStatusDAO
    {
        List<SalaryIncrementStatus> GetAllSalaryIncrementStatus(DBConnection dbConnection);
    }

    public class SalaryIncrementStatusDAOSqlImpl : SalaryIncrementStatusDAO
    {
        public List<SalaryIncrementStatus> GetAllSalaryIncrementStatus(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Salary_Increment_Status";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SalaryIncrementStatus>(dbConnection.dr);
        }
    }
}
