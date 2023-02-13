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
    public interface SupplierController
    {
        int Save(Supplier supplier);

        int Update(Supplier supplier);

        List<Supplier> GetAllSupplier();
    }

    public class SupplierControllerImpl : SupplierController
    {
        DBConnection dBConnection;
        SupplierDAO supplierDAO = DAOFactory.createSupplierDAO();

        public int Save(Supplier supplier)
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierDAO.Save(supplier, dBConnection);
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

        public int Update(Supplier supplier)
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierDAO.Update(supplier, dBConnection);
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

        public List<Supplier> GetAllSupplier()
        {
            try
            {
                dBConnection = new DBConnection();
                return supplierDAO.GetAllSupplier(dBConnection);
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
