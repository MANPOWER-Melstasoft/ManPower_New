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
    public interface ApprovalHistoryController
    {
        int Save(ApprovalHistory approvalHistory);

        int Update(ApprovalHistory approvalHistory);

        List<ApprovalType> GetAllApprovalHistory();
    }

    public class ApprovalHistoryControllerImpl : ApprovalHistoryController
    {
        DBConnection dBConnection;
        ApprovalHistoryDAO approvalHistoryDAO = DAOFactory.createApprovalHistoryDAO();
        public int Save(ApprovalHistory approvalHistory)
        {
            try
            {
                dBConnection = new DBConnection();
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

        public int Update(ApprovalHistory approvalHistory)
        {
            try
            {
                dBConnection = new DBConnection();
                return approvalHistoryDAO.Update(approvalHistory, dBConnection);
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
        public List<ApprovalType> GetAllApprovalHistory()
        {
            try
            {
                dBConnection = new DBConnection();
                return approvalHistoryDAO.GetAllApprovalHistory(dBConnection);
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
