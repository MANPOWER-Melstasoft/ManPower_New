using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface AutUserFunctionController
    {
        int Save(AutUserFunction autUserFunction);
        int SaveMultiple(List<AutUserFunction> autUserFunction);
        int Delete(AutUserFunction autUserFunction);
        List<AutUserFunction> GetAllAutUserFunctionByUserId(bool withFunctions, int AutUserId);
        List<AutUserFunction> GetAllAutUserFunction(bool withFunctions);
    }

    public class AutUserFunctionControllerSqlImpl : AutUserFunctionController
    {
        AutUserFunctionDAO autUserFunctionDAO = DAOFactory.CreateAutUserFunctionDAO();

        public int Save(AutUserFunction autUserFunction)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return autUserFunctionDAO.Save(autUserFunction, dbConnection);
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
        public int SaveMultiple(List<AutUserFunction> autUserFunction)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                int output = -1;

                foreach (var item in autUserFunction)
                {
                    output = autUserFunctionDAO.Save(item, dbConnection);
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

        public int Delete(AutUserFunction autUserFunction)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return autUserFunctionDAO.Delete(autUserFunction, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

        public List<AutUserFunction> GetAllAutUserFunctionByUserId(bool withFunctions, int AutUserId)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                List<AutUserFunction> autUserFunctionList = autUserFunctionDAO.GetAllAutUserFunctionByUserId(AutUserId, dbConnection);

                if (withFunctions)
                {
                    AutFunctionDAO autFunctionDAO = DAOFactory.CreateAutFunctionDAO();
                    List<AutFunction> autFunctionList = autFunctionDAO.GetAllAutFunction(dbConnection);

                    foreach (var userFunction in autUserFunctionList)
                    {
                        userFunction.autFunction = autFunctionList.Where(x => x.AutFunctionId == userFunction.AutFunctionId).Single();
                    }
                }

                return autUserFunctionList;

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

        public List<AutUserFunction> GetAllAutUserFunction(bool withFunctions)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                List<AutUserFunction> autUserFunctionList = autUserFunctionDAO.GetAllAutUserFunction(dbConnection);
                if (withFunctions)
                {
                    AutFunctionDAO autFunctionDAO = DAOFactory.CreateAutFunctionDAO();
                    List<AutFunction> autFunctionList = autFunctionDAO.GetAllAutFunction(dbConnection);

                    foreach (var userFunction in autUserFunctionList)
                    {
                        userFunction.autFunction = autFunctionList.Where(x => x.AutFunctionId == userFunction.AutFunctionId).Single();
                    }
                }

                return autUserFunctionList;

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
