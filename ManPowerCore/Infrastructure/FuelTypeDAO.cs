using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface FuelTypeDAO
    {
        List<FuelType> GetFuelTypes(DBConnection dbConnection);
    }
    public class FuelTypeDAOSqlImpl : FuelTypeDAO
    {
        public List<FuelType> GetFuelTypes(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();



            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "SELECT * FROM Fuel_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();


            return dataAccessObject.ReadCollection<FuelType>(dbConnection.dr);

        }

    }


}
