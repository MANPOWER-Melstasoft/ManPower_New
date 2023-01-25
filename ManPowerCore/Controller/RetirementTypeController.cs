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
    public interface RetirementTypeController
    {
        List<RetirementType> GetAllRetirementType(bool with0);
    }

    public class RetirementTypeControllerSqlImpl : RetirementTypeController
    {
        public List<RetirementType> GetAllRetirementType(bool with0)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                RetirementTypeDAO DAO = DAOFactory.CreateRetirementTypeDAO();
                return DAO.GetAllRetirementType(with0, dbConnection);
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
