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
    public interface DistricDsParentController
    {
        int Save(DistricDsParent districDsParent);
        int Update(DistricDsParent districDsParent);
        int Delete(DistricDsParent districDsParent);
        List<DistricDsParent> GetAllDistricDsParent(bool withUser, bool withDepartment);
        DistricDsParent GetDistricDsParent(DistricDsParent districDsParent);
    }

    public class DistricDsParentControllerImpl : DistricDsParentController
    {
        DistricDsParentDAO districDsParentDAO = DAOFactory.CreateDistricDsParentDAO();

        public int Save(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return districDsParentDAO.Save(districDsParent, dbConnection);
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

        public int Update(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return districDsParentDAO.Update(districDsParent, dbConnection);
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

        public int Delete(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return districDsParentDAO.Delete(districDsParent, dbConnection);
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

        public List<DistricDsParent> GetAllDistricDsParent(bool withUser, bool withDepartment)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                List<DistricDsParent> districDsParentsList = districDsParentDAO.GetAllDistricDsParent(dbConnection);

                if (withUser)
                {
                    SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();

                    foreach (var item in districDsParentsList)
                    {
                        item.systemUser = systemUserDAO.GetSystemUser(item.ParentUserId, dbConnection);
                    }
                }

                if (withDepartment)
                {
                    DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();

                    foreach (var item in districDsParentsList)
                    {
                        item.departmentUnit = departmentUnitDAO.GetDepartmentUnit(item.DepartmentId, dbConnection);
                    }
                }

                return districDsParentsList;

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

        public DistricDsParent GetDistricDsParent(DistricDsParent districDsParent)
        {
            DBConnection dbConnection = null;
            try
            {
                dbConnection = new DBConnection();
                return districDsParentDAO.GetDistricDsParent(districDsParent, dbConnection);

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
