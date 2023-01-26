using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ContractTypeDAO
    {
        List<ContractType> GetAllContractType(DBConnection dbConnection);

        ContractType GetContractTypeById(int id, DBConnection dbConnection);
    }
    public class ContractTypeDAOImpl : ContractTypeDAO
    {
        public List<ContractType> GetAllContractType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CONTRACT_TYPE WHERE IS_ACTIVE = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ContractType>(dbConnection.dr);

        }

        public ContractType GetContractTypeById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CONTRACT_TYPES WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ContractType>(dbConnection.dr);

        }

    }
}
