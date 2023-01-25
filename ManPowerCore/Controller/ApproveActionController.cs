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
    public interface ApproveActionController
    {
        List<ApproveAction> GetAllApproveAction(bool with0);
    }

    public class ApproveActionControllerSqlImpl : ApproveActionController
    {
        public List<ApproveAction> GetAllApproveAction(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ApproveActionDAO DAO = DAOFactory.CreateApproveActionDAO();
                return DAO.GetAllApproveAction(with0, dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}
