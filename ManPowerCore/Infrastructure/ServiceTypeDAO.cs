using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ServiceTypeDAO
    {
        List<ServiceType> GetAllServiceType(DBConnection dbConnection);

        //ServiceType GetServiceTypeById(int id, DBConnection dbConnection);
    }

    public class ServiceTypeDAOImpl : ServiceTypeDAO
    {
        public List<ServiceType> GetAllServiceType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM SERVICE_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ServiceType>(dbConnection.dr);

        }

    }
}
