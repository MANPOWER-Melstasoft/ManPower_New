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
    public interface AutSystemRoleFunctionController
    {
        List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId);
        int Change(AutSystemRoleFunction autSystemRoleFunction);
    }

    public class AutSystemRoleFunctionControllerImpl : AutSystemRoleFunctionController
    {
        public int Change(AutSystemRoleFunction autSystemRoleFunction)
        {
            DBConnection dbConnection = null;
            try
            {
                int output = 0;
                dbConnection = new DBConnection();
                AutSystemRoleFunctionDAO DAO = DAOFactory.CreateAutSystemRoleFunctionDAO();

                AutSystemRoleFunction autUserFunctionTest = DAO.GetAutSystemRoleFunction(autSystemRoleFunction, dbConnection);

                if (autUserFunctionTest.AutFunctionId == 0 && autUserFunctionTest.UserTypeId == 0)
                {
                    output = DAO.Save(autSystemRoleFunction, dbConnection);
                }
                else
                {
                    output = DAO.Delete(autSystemRoleFunction, dbConnection);

                }

                return output;

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

        public List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                AutSystemRoleFunctionDAO DAO = DAOFactory.CreateAutSystemRoleFunctionDAO();
                return DAO.GetAllAutSystemRoleFunctionById(UserTypeId, dbConnection);
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
