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
    public interface VoteTypeController
    {
        int Save(VoteType voteType);
        int Delete(int id);
        List<VoteType> GetAllVoteType(bool with0);
    }
    public class VoteTypeControllerImpl : VoteTypeController
    {
        DBConnection dBConnection;
        VoteTypeDAO voteTypeDAO = DAOFactory.CreateVoteTypeDAO();

        public int Save(VoteType voteType)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteTypeDAO.Save(voteType, dBConnection);
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
                return voteTypeDAO.Delete(id, dBConnection);
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

        public List<VoteType> GetAllVoteType(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteTypeDAO.GetAllVoteType(with0, dBConnection);
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
