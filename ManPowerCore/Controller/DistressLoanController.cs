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
    public interface DistressLoanController
    {
        int Save(DistressLoan distressLoan);

        int Update(DistressLoan distressLoan);

        int UpdatetoAdmin(DistressLoan distressLoan);

        List<DistressLoan> GetAllDistressLoan();
    }

    public class DistressLoanControllerImpl : DistressLoanController
    {
        DBConnection dBConnection;
        DistressLoanDAO distressLoanDAO = DAOFactory.createDistressLoanDAO();
        public int Save(DistressLoan distressLoan)
        {
            try
            {
                dBConnection = new DBConnection();
                return distressLoanDAO.Save(distressLoan, dBConnection);
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

        public int Update(DistressLoan distressLoan)
        {
            try
            {
                dBConnection = new DBConnection();
                return distressLoanDAO.Update(distressLoan, dBConnection);
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

        public int UpdatetoAdmin(DistressLoan distressLoan)
        {
            try
            {
                dBConnection = new DBConnection();
                return distressLoanDAO.UpdatetoAdmin(distressLoan, dBConnection);
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

        public List<DistressLoan> GetAllDistressLoan()
        {
            try
            {
                dBConnection = new DBConnection();
                return distressLoanDAO.GetAllDistressLoan(dBConnection);
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
