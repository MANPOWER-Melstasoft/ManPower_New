using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface AccountCodeController
    {
        int Save(AccountCode accountCode);

        int Update(AccountCode accountCode);

        List<AccountCode> GetAllAccountCode();
    }

    public class AccountCodeControllerImpl : AccountCodeController
    {
        DBConnection dBConnection;
        AccountCodeDAO accountCodeDAO = DAOFactory.createAccountCodeDAO();

        public int Save(AccountCode accountCode)
        {
            try
            {
                dBConnection = new DBConnection();
                return accountCodeDAO.Save(accountCode, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int Update(AccountCode accountCode)
        {
            try
            {
                dBConnection = new DBConnection();
                return accountCodeDAO.Update(accountCode, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<AccountCode> GetAllAccountCode()
        {
            try
            {
                dBConnection = new DBConnection();
                return accountCodeDAO.GetAllAccountCode(dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}
