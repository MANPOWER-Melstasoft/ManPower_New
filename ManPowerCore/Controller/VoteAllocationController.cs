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
    public interface VoteAllocationController
    {
        int Save(VoteAllocation voteAllocation);
        int Delete(int id);
        int ChangeRemain(VoteAllocation voteAllocation);
        List<VoteAllocation> GetAllVoteAllocation(bool with0);
        VoteAllocation GetVoteAllocation(int id);
        VoteAllocation CheckVoteAllocationExists(int typeId, DateTime year);
        VoteAllocation CheckVoteAllocationNumberExists(string Number);

    }
    public class VoteAllocationControllerImpl : VoteAllocationController
    {
        DBConnection dBConnection;
        VoteAllocationDAO voteAllocationDAO = DAOFactory.CreateVoteAllocationDAO();

        public int Save(VoteAllocation voteAllocation)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.Save(voteAllocation, dBConnection);
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
                return voteAllocationDAO.Delete(id, dBConnection);
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

        public int ChangeRemain(VoteAllocation voteAllocation)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.ChangeRemain(voteAllocation, dBConnection);
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

        public List<VoteAllocation> GetAllVoteAllocation(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.GetAllVoteAllocation(with0, dBConnection);
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

        public VoteAllocation GetVoteAllocation(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.GetVoteAllocation(id, dBConnection);
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

        public VoteAllocation CheckVoteAllocationExists(int typeId, DateTime year)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.CheckVoteAllocationExists(typeId, year, dBConnection);
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

        public VoteAllocation CheckVoteAllocationNumberExists(string Number)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteAllocationDAO.CheckVoteAllocationNumberExists(Number, dBConnection);
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
