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

        List<LoanDetail> GetAllLoanDetailWithStatus(bool withStatus, bool withLoanType);
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

        public List<LoanDetail> GetAllLoanDetailWithStatus(bool withStatus, bool withLoanType)
        {
            ApprovalTypeDAO approvalTypeDAO = DAOFactory.createApprovalTypeDAO();
            LoanTypeDAO loanTypeDAO = DAOFactory.createLoanTypeDAO();

            List<ApprovalType> approvalTypeList = new List<ApprovalType>();
            List<LoanType> loanTypeList = new List<LoanType>();
            List<LoanDetail> loanDetailList = new List<LoanDetail>();
            try
            {
                dBConnection = new DBConnection();

                loanDetailList = loanDetailDAO.GetAllLoanDetail(dBConnection);
                loanTypeList = loanTypeDAO.GetAllLoanType(dBConnection);
                approvalTypeList = approvalTypeDAO.GetAllApprovalType(dBConnection);

                if (withStatus)
                {
                    foreach (var item in loanDetailList)
                    {
                        item.ApprovalType = approvalTypeList.Where(x => x.ApprovalStatusId == item.ApprovalStatusId).Single();
                    }
                }

                if (withLoanType)
                {
                    foreach (var item in loanDetailList)
                    {
                        item.LoanType = loanTypeList.Where(x => x.Id == item.LoanTypeId).Single();
                    }
                }

                return loanDetailList;
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
