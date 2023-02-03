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
                AutSystemRoleFunctionDAO AutSystemRoleFunctionDAO = DAOFactory.CreateAutSystemRoleFunctionDAO();
                AutUserFunctionDAO autUserFunctionDAO = DAOFactory.CreateAutUserFunctionDAO();


                //--get all autUserFuntion with user type---
                List<AutUserFunction> autUserFunctionListGetAll = autUserFunctionDAO.GetAutUserFunctionAllUserGroupBy(autSystemRoleFunction.UserTypeId, dbConnection);

                List<AutUserFunction> autUserFunctionListCheck = autUserFunctionDAO.GetAutUserFunctionCheckByAll(autSystemRoleFunction.AutFunctionId, autSystemRoleFunction.UserTypeId, dbConnection);
                //-----------------------------------------


                AutSystemRoleFunction autUserFunctionTest = AutSystemRoleFunctionDAO.GetAutSystemRoleFunction(autSystemRoleFunction, dbConnection);

                if (autUserFunctionTest.AutFunctionId == 0 && autUserFunctionTest.UserTypeId == 0)
                {
                    foreach (var item in autUserFunctionListCheck)
                    {
                        autUserFunctionDAO.Delete(item, dbConnection);
                    }
                    foreach (var item in autUserFunctionListGetAll)
                    {
                        item.AutFunctionId = autSystemRoleFunction.AutFunctionId;
                        autUserFunctionDAO.Save(item, dbConnection);
                    }
                    output = AutSystemRoleFunctionDAO.Save(autSystemRoleFunction, dbConnection);
                }
                else
                {
                    foreach (var item in autUserFunctionListCheck)
                    {
                        autUserFunctionDAO.Delete(item, dbConnection);
                    }
                    output = AutSystemRoleFunctionDAO.Delete(autSystemRoleFunction, dbConnection);
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
