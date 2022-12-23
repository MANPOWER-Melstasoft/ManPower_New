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
    public interface VoteLedgerController
    {
        int Save(VoteLedger voteLedger);
        int Delete(int id);
        int ApproveVoteLedger(VoteLedger voteLedger);
        List<VoteLedger> GetAllVoteLedger(bool with0);
        VoteLedger GetVoteLedger(int id);
    }
    public class VoteLedgerControllerImpl : VoteLedgerController
    {
        DBConnection dBConnection;
        VoteLedgerDAO voteLedgerDAO = DAOFactory.CreateVoteLedgerDAO();

        public int Save(VoteLedger voteLedger)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteLedgerDAO.Save(voteLedger, dBConnection);
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
                return voteLedgerDAO.Delete(id, dBConnection);
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

        public int ApproveVoteLedger(VoteLedger voteLedger)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteLedgerDAO.ApproveVoteLedger(voteLedger, dBConnection);
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

        public List<VoteLedger> GetAllVoteLedger(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteLedgerDAO.GetAllVoteLedger(with0, dBConnection);
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

        public VoteLedger GetVoteLedger(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return voteLedgerDAO.GetVoteLedger(id, dBConnection);
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
