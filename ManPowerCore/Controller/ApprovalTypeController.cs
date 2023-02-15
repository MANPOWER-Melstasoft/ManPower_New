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
    public interface ApprovalTypeController
    {
        int Save(ApprovalType approvalType);

        int Update(ApprovalType approvalType);

        List<ApprovalType> GetAllTrainingRequests();
    }

    public class ApprovalTypeControllerImpl : ApprovalTypeController
    {
        DBConnection dBConnection;
        ApprovalTypeDAO approvalTypeDAO = DAOFactory.createApprovalTypeDAO();
        public int Save(ApprovalType approvalType)
        {
            try
            {
                dBConnection = new DBConnection();
                return approvalTypeDAO.Save(approvalType, dBConnection);
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

        public int Update(ApprovalType approvalType)
        {
            try
            {
                dBConnection = new DBConnection();
                return approvalTypeDAO.Update(approvalType, dBConnection);
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

        public List<ApprovalType> GetAllTrainingRequests()
        {
            try
            {
                dBConnection = new DBConnection();
                return approvalTypeDAO.GetAllApprovalType(dBConnection);
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
