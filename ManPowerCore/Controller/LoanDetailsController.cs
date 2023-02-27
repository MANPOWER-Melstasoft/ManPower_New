using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface LoanDetailsController
    {
        int Save(LoanDetail loanDetail);

        int SaveAll(LoanDetail loanDetail, DistressLoan distressLoan, List<GuarantorDetail> guarantorDetailList, List<RequestorGuarantor> requestorGuarantorsList);

        int Update(LoanDetail loanDetail);

        int UpdateStatus(int id, int approvalstatusId);
        int UpdateStatusWithHistory(int id, int approvalstatusId, ApprovalHistory approvalHistory, LoanDetail loanDetail, DistressLoan distressLoan);

        List<LoanDetail> GetAllLoanDetail();

        List<LoanDetail> GetAllLoanDetailWithStatus(bool withStatus, bool withLoanType);

        DataTable getLoanReport();
    }

    public class LoanDetailsControllerImpl : LoanDetailsController
    {
        DBConnection dBConnection;
        LoanDetailDAO loanDetailDAO = DAOFactory.createLoanDetailDAO();
        GuarantorDetailDAO guarantorDetailDAO = DAOFactory.createGuarantorDetailDAO();
        RequestorGuarantorDAO requestorGuarantorDAO = DAOFactory.createRequestorGuarantorDAO();
        DistressLoanDAO DistressLoanDAO = DAOFactory.createDistressLoanDAO();
        ApprovalHistoryDAO approvalHistoryDAO = DAOFactory.createApprovalHistoryDAO();

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

        public int SaveAll(LoanDetail loanDetail, DistressLoan distressLoan, List<GuarantorDetail> guarantorDetailList, List<RequestorGuarantor> requestorGuarantorsList)
        {

            try
            {
                dBConnection = new DBConnection();

                int loanDetailId = loanDetailDAO.Save(loanDetail, dBConnection);

                distressLoan.LoanDetailsId = loanDetailId;

                int distressLoanId = DistressLoanDAO.Save(distressLoan, dBConnection);

                if (guarantorDetailList.Count() > 0)
                {
                    for (int i = 0; i < guarantorDetailList.Count(); i++)
                    {
                        guarantorDetailList[i].DistressLoanId = distressLoanId; //change
                        guarantorDetailDAO.Save(guarantorDetailList[i], dBConnection);

                    }
                }

                if (requestorGuarantorsList.Count() > 0)
                {
                    for (int i = 0; i < requestorGuarantorsList.Count(); i++)
                    {
                        requestorGuarantorsList[i].DistressLoanId = distressLoanId; //change
                        requestorGuarantorDAO.Save(requestorGuarantorsList[i], dBConnection);
                    }
                }

                return 1;
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

        public int UpdateStatusWithHistory(int id, int approvalstatusId, ApprovalHistory approvalHistory, LoanDetail loanDetail, DistressLoan distressLoan)
        {
            try
            {
                dBConnection = new DBConnection();


                if (distressLoan != null)
                {
                    DistressLoanDAO.Update(distressLoan, dBConnection);

                }

                if (loanDetail != null)
                {
                    loanDetailDAO.Update(loanDetail, dBConnection);
                }
                else
                {
                    loanDetailDAO.UpdateStatus(id, approvalstatusId, dBConnection);

                }

                return approvalHistoryDAO.Save(approvalHistory, dBConnection);


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

        public DataTable getLoanReport()
        {
            try
            {
                dBConnection = new DBConnection();
                return loanDetailDAO.GetLoanReport(dBConnection);
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
