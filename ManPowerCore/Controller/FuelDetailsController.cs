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
        List<FuelDetailsDomain> GetAll();

        List<FuelDetailsDomain> GetAllWithFuleTypeDetails(bool WithFuelType);

    }
    public class FuelDetailsControllerImpl : FuelDetailsController
    {
        DBConnection dBConnection;
        FuelDetailsDAO fuelDetailsDAO = DAOFactory.CreatefuelDetailsDAO();

        public List<FuelDetailsDomain> GetAll()
        {
            try
            {
                dBConnection = new DBConnection();

                return fuelDetailsDAO.GetAll(dBConnection);

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

        public List<FuelDetailsDomain> GetAllWithFuleTypeDetails(bool WithFuelType)
        {
            FuelTypeDAO fuelTypeDAO = DAOFactory.CreateFuelTypeDAO();

            List<FuelDetailsDomain> fuelDetails = new List<FuelDetailsDomain>();
            List<FuelType> fuelTypesDetails = new List<FuelType>();
            try
            {
                dBConnection = new DBConnection();

                fuelDetails = fuelDetailsDAO.GetAll(dBConnection);

                if (WithFuelType)
                {
                    fuelTypesDetails = fuelTypeDAO.GetFuelTypes(dBConnection);

                    foreach (var item in fuelDetails)
                    {
                        foreach (var itemFueltype in fuelTypesDetails)
                        {
                            if (item.FuelTypeId == itemFueltype.FuelTypeId)
                            {
                                item.FuelTypeName = itemFueltype.FuelTypeName;
                                break;
                            }

                        }
                    }
                }
                return fuelDetails;

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
