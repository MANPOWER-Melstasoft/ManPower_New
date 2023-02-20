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
    public interface LoanDetailsController
    {
        int Save(LoanDetail loanDetail);

        int Update(LoanDetail loanDetail);

        int UpdateStatus(int id, int approvalstatusId);

        List<LoanDetail> GetAllLoanDetail();
    }

    public class LoanDetailsControllerImpl : LoanDetailsController
    {
        DBConnection dBConnection;
        LoanDetailDAO loanDetailDAO = DAOFactory.createLoanDetailDAO();
        public int Save(LoanDetail loanDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return loanDetailDAO.Save(loanDetail, dBConnection);
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
        public int Update(LoanDetail loanDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                return loanDetailDAO.Update(loanDetail, dBConnection);
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

        public int UpdateStatus(int id, int approvalstatusId)
        {
            try
            {
                dBConnection = new DBConnection();
                return loanDetailDAO.UpdateStatus(id, approvalstatusId, dBConnection);
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

        public List<LoanDetail> GetAllLoanDetail()
        {
            try
            {
                dBConnection = new DBConnection();
                return loanDetailDAO.GetAllLoanDetail(dBConnection);
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
