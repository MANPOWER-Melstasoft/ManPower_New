using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface ServiceTypeController
    {
        List<ServiceType> GetAllServiceType();
    }

    public class ServiceTypeControllerImpl : ServiceTypeController
    {
        DBConnection dBConnection;
        ServiceTypeDAO aa = DAOFactory.CreateServiceTypeDAO();

        public List<ServiceType> GetAllServiceType()

        {
            try
            {
                dBConnection = new DBConnection();
                List<ServiceType> list = aa.GetAllServiceType(dBConnection);

                return list;
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
