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
    public interface ResignationController
    {
        int Save(Resignation resignation);
        int Delete(int id);
        int Update(Resignation resignation);
        List<Resignation> GetAllResignation(bool with0);
        Resignation GetResignation(int Id);
    }

    public class ResignationControllerSqlImpl : ResignationController
    {
        ResignationDAO resignationDAO = DAOFactory.CreateResignationDAO();
        DBConnection dBConnection;

        public int Save(Resignation resignation)
        {
            try
            {
                dBConnection = new DBConnection();
                return resignationDAO.Save(resignation, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int Update(Resignation resignation)
        {
            try
            {
                dBConnection = new DBConnection();
                return resignationDAO.Update(resignation, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int Delete(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return resignationDAO.Delete(id, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<Resignation> GetAllResignation(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                return resignationDAO.GetAllResignation(with0, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public Resignation GetResignation(int Id)
        {
            try
            {
                dBConnection = new DBConnection();
                return resignationDAO.GetResignation(Id, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

    }
}
