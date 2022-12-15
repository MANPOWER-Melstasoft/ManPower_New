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
    public interface AutFunctionController
    {
        List<AutFunction> GetAllAutFunctionById(int AutFunctionId);
        List<AutFunction> GetAllAutFunction();
    }
    public class AutFunctionControllerImpl : AutFunctionController
    {
        public List<AutFunction> GetAllAutFunctionById(int AutFunctionId)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                AutFunctionDAO DAO = DAOFactory.CreateAutFunctionDAO();
                return DAO.GetAllAutFunctionById(AutFunctionId, dbConnection);
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

        public List<AutFunction> GetAllAutFunction()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                AutFunctionDAO DAO = DAOFactory.CreateAutFunctionDAO();
                return DAO.GetAllAutFunction(dbConnection);
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
