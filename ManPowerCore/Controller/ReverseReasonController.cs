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
    public interface ReverseReasonController
    {
        List<ReverseReason> GetAllReverseReason(bool with0);
    }

    public class ReverseReasonControllerSqlImpl : ReverseReasonController
    {
        public List<ReverseReason> GetAllReverseReason(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ReverseReasonDAO DAO = DAOFactory.CreateReverseReasonDAO();
                return DAO.GetAllReverseReason(with0, dbConnection);
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
