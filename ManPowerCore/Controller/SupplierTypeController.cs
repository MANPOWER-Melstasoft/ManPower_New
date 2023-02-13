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
    public interface SupplierTypeController
    {
        int Save(SupplierType supplierType);

        int Update(SupplierType supplierType);

        List<SupplierType> GetAllSupplierType();
    }

    public class SupplierTypeControllerImpl : SupplierTypeController
    {
        DBConnection dBConnection;
        SupplierTypeDAO supplierTypeDAO = DAOFactory.createSupplierTypeDAO();

        public int Save(SupplierType supplierType)
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierTypeDAO.Save(supplierType, dBConnection);
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

        public int Update(SupplierType supplierType)
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierTypeDAO.Update(supplierType, dBConnection);
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

        public List<SupplierType> GetAllSupplierType()
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierTypeDAO.GetAllSupplierType(dBConnection);
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
