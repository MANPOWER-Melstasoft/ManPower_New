using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AccountCodeDAO
    {
        int Save(AccountCode accountCode, DBConnection dbConnection);

        int Update(AccountCode accountCode, DBConnection dbConnection);

        List<AccountCode> GetAllAccountCode(DBConnection dbConnection);
    }

    public class AccountCodeDAOSqlImpl : AccountCodeDAO
    {
        public int Save(AccountCode accountCode, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Account_Code (Description, Ledger_Code, Is_Active) " +
                "VALUES (@Description, @LedgerCode, @IsActive)";

            dbConnection.cmd.Parameters.AddWithValue("@Description", accountCode.Description);
            dbConnection.cmd.Parameters.AddWithValue("@LedgerCode", accountCode.LedgerCode);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", accountCode.IsActive);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(AccountCode accountCode, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Account_Code " +
                "SET Description = @Description, Ledger_Code = @LedgerCode, Is_Active = @IsActive " +
                "WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Description", accountCode.Description);
            dbConnection.cmd.Parameters.AddWithValue("@LedgerCode", accountCode.LedgerCode);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", accountCode.IsActive);
            dbConnection.cmd.Parameters.AddWithValue("@Id", accountCode.Id);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<AccountCode> GetAllAccountCode(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Account_Code";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<AccountCode>(dbConnection.dr);
        }
    }
}
