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
    public interface TransfersRetirementResignationMainController
    {
        int Save(TransfersRetirementResignationMain obj);
        int Delete(int id);
        int Update(TransfersRetirementResignationMain obj);
        int Recommend(TransfersRetirementResignationMain obj);
        List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0);
        TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id);
    }

    public class TransfersRetirementResignationMainControllerSqlImpl : TransfersRetirementResignationMainController
    {
        TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = DAOFactory.CreateTransfersRetirementResignationMainDAO();
        DBConnection dBConnection;

        public int Save(TransfersRetirementResignationMain obj)
        {
            try
            {
                dBConnection = new DBConnection();
                return transfersRetirementResignationMainDAO.Save(obj, dBConnection);
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

        public int Update(TransfersRetirementResignationMain obj)
        {
            try
            {
                dBConnection = new DBConnection();
                return transfersRetirementResignationMainDAO.Approve(obj, dBConnection);
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

        public int Recommend(TransfersRetirementResignationMain obj)
        {
            try
            {
                dBConnection = new DBConnection();
                return transfersRetirementResignationMainDAO.Recommend(obj, dBConnection);
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
                return transfersRetirementResignationMainDAO.Delete(id, dBConnection);
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

        public List<TransfersRetirementResignationMain> GetAllTransfersRetirementResignation(bool with0)
        {
            try
            {
                dBConnection = new DBConnection();
                RetirementTypeDAO DAO = DAOFactory.CreateRetirementTypeDAO();
                List<TransfersRetirementResignationMain> list = transfersRetirementResignationMainDAO.GetAllTransfersRetirementResignation(with0, dBConnection);

                RequestTypeDAO requestTypeDAO = DAOFactory.CreateRequestTypeDAO();
                TransfersRetirementResignationStatusDAO statusDAO = DAOFactory.CreateTransfersRetirementResignationStatusDAO();
                EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();

                foreach (var item in list)
                {
                    item.requestType = requestTypeDAO.GetRequestType(item.RequestTypeId, dBConnection);
                    item.status = statusDAO.GetStatus(item.StatusId, dBConnection);
                    item.employee = employeeDAO.GetEmployeeById(item.EmployeeId, dBConnection);
                }

                return list;
            }
            catch (Exception ex)
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

        public TransfersRetirementResignationMain GetTransfersRetirementResignation(int Id)
        {
            try
            {
                dBConnection = new DBConnection();
                EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();

                TransfersRetirementResignationMain transfersRetirementResignationMain = new TransfersRetirementResignationMain();
                transfersRetirementResignationMain = transfersRetirementResignationMainDAO.GetTransfersRetirementResignation(Id, dBConnection);
                transfersRetirementResignationMain.employee = employeeDAO.GetEmployeeById(transfersRetirementResignationMain.EmployeeId, dBConnection);

                return transfersRetirementResignationMain;
            }
            catch (Exception ex)
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
