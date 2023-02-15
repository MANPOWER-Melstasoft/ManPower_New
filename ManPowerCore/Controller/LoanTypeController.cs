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
    public interface LoanTypeController
    {
        int Save(LoanType loanType);

        int Update(LoanType loanType);

        List<LoanType> GetAllLoanType();
    }

    public class LoanTypeControllerImpl : LoanTypeController
    {
        DBConnection dBConnection;
        LoanTypeDAO loanTypeDAO = DAOFactory.createLoanTypeDAO();
        public int Save(LoanType loanType)
        {
            try
            {
                dBConnection = new DBConnection();
                return loanTypeDAO.Save(loanType, dBConnection);
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

        public int Update(LoanType loanType)
        {
            try
            {
                dBConnection = new DBConnection();
                return loanTypeDAO.Update(loanType, dBConnection);
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

        public List<LoanType> GetAllLoanType()
        {
            try
            {
                dBConnection = new DBConnection();
                return loanTypeDAO.GetAllLoanType(dBConnection);
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
