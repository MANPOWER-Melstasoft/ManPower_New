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
    public interface RequestorGuarantorController
    {
        int Save(RequestorGuarantor requestorGuarantor);

        int Update(RequestorGuarantor requestorGuarantor);

        List<RequestorGuarantor> GetAllRequestorGuarantor();
    }

    public class RequestorGuarantorControllerImpl : RequestorGuarantorController
    {
        DBConnection dBConnection;
        RequestorGuarantorDAO requestorGuarantorDAO = DAOFactory.createRequestorGuarantorDAO();
        public int Save(RequestorGuarantor requestorGuarantor)
        {
            try
            {
                dBConnection = new DBConnection();
                return requestorGuarantorDAO.Save(requestorGuarantor, dBConnection);
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

        public int Update(RequestorGuarantor requestorGuarantor)
        {
            try
            {
                dBConnection = new DBConnection();
                return requestorGuarantorDAO.Update(requestorGuarantor, dBConnection);
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

        public List<RequestorGuarantor> GetAllRequestorGuarantor()
        {
            try
            {
                dBConnection = new DBConnection();
                return requestorGuarantorDAO.GetAllRequestorGuarantor(dBConnection);
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
