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
    public interface TransferController
    {
        int Save(TransfersRetirementResignationMain transfersRetirementResignationMain, Transfer transfer);
        int Delete(int id);
        int Update(Transfer transfer);
        List<Transfer> GetAllTransfer(bool with0);
        Transfer GetTransferByMainId(int Id);
    }

    public class TransferControllerSqlImpl : TransferController
    {
        TransferDAO transferDAO = DAOFactory.CreateTransferDAO();
        DBConnection dBConnection;

        public int Save(TransfersRetirementResignationMain transfersRetirementResignationMain, Transfer transfer)
        {
            try
            {
                int output = 0;
                dBConnection = new DBConnection();

                TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();
                transfer.MainId = transfersRetirementResignationMainDAO.Save(transfersRetirementResignationMain, dBConnection);
                output = transferDAO.Save(transfer, dBConnection);

                return output;
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

        public int Update(Transfer transfer)
        {
            try
            {
                dBConnection = new DBConnection();
                return transferDAO.Update(transfer, dBConnection);
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
                return transferDAO.Delete(id, dBConnection);
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

        public List<Transfer> GetAllTransfer(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                return transferDAO.GetAllTransfer(with0, dBConnection);
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

        public Transfer GetTransferByMainId(int Id)
        {
            try
            {
                dBConnection = new DBConnection();
                return transferDAO.GetTransferByMainId(Id, dBConnection);
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
