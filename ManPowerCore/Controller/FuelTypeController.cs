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
    public interface FuelTypeController
    {
        List<FuelType> GetFuelTypes();
    }
    public class FuelTypeControllerImpl : FuelTypeController
    {
        DBConnection dBConnection;
        FuelTypeDAO fuelTypeDAO = DAOFactory.CreateFuelTypeDAO();

        public List<FuelType> GetFuelTypes()
        {
            try
            {
                dBConnection = new DBConnection();

                return fuelTypeDAO.GetFuelTypes(dBConnection);

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
