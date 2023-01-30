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
    public interface TransfersRetirementResignationStatusController
    {
        List<TransfersRetirementResignationStatus> GetAllStatus(bool with0);
    }

    public class TransfersRetirementResignationStatusControllerSqlImpl : TransfersRetirementResignationStatusController
    {
        public List<TransfersRetirementResignationStatus> GetAllStatus(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TransfersRetirementResignationStatusDAO DAO = DAOFactory.CreateTransfersRetirementResignationStatusDAO();
                return DAO.GetAllStatus(with0, dbConnection);
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
