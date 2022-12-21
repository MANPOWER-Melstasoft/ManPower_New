using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface ContractTypeController
    {
        List<ContractType> GetAllContractType();

        ContractType GetContractType(int id);
    }

    public class ContractTypeControllerImpl : ContractTypeController
    {
        public List<ContractType> GetAllContractType()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                ContractTypeDAO DAO = DAOFactory.CreateContractTypeDAO();
                List<ContractType> list = DAO.GetAllContractType(dBConnection);
                return list;
            }

            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }

            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public ContractType GetContractType(int id)
        {
            DBConnection dbConnection = new DBConnection();

            try
            {
                ContractTypeDAO DAO = DAOFactory.CreateContractTypeDAO();
                ContractType list = DAO.GetContractTypeById(id, dbConnection);
                return list;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                return null;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}