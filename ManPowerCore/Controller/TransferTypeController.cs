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
    public interface TransferTypeController
    {
        List<TransferType> GetAllTransferType(bool with0);
    }

    public class TransferTypeControllerSqlImpl : TransferTypeController
    {
        public List<TransferType> GetAllTransferType(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TransferTypeDAO DAO = DAOFactory.CreateTransferTypeDAO();
                return DAO.GetAllTransferType(with0, dbConnection);
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
