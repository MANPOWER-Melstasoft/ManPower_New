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
    public interface FuelDetailsController
    {
        int Save(FuelDetailsDomain fuelDetailsDomain);

    }
    public class FuelDetailsControllerImpl : FuelDetailsController
    {
        DBConnection dBConnection;
        FuelDetailsDAO fuelDetailsDAO = DAOFactory.CreatefuelDetailsDAO();
        public int Save(FuelDetailsDomain fuelDetailsDomain)
        {
            try
            {
                dBConnection = new DBConnection();

                return fuelDetailsDAO.SaveAll(fuelDetailsDomain, dBConnection);

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
