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
    public interface MaintenanceCategoryController
    {
        List<MaintenanceCategory> GetAllMaintenanceCategory();
        MaintenanceCategory GetMaintenanceCategory(int id);
    }

    public class MaintenanceCategoryControllerImpl : MaintenanceCategoryController
    {
        DBConnection dBConnection;
        MaintenanceCategoryDAO MaintenanceCategoryDAO = DAOFactory.CreateMaintenanceCategoryDAO();

        public List<MaintenanceCategory> GetAllMaintenanceCategory()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                MaintenanceCategoryDAO MaintenanceCategoryDAO = DAOFactory.CreateMaintenanceCategoryDAO();
                return MaintenanceCategoryDAO.GetAllMaintenanceCategory(dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }

        MaintenanceCategory MaintenanceCategoryController.GetMaintenanceCategory(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                MaintenanceCategoryDAO MaintenanceCategoryDAO = DAOFactory.CreateMaintenanceCategoryDAO();
                return MaintenanceCategoryDAO.GetMaintenanceCategory(id, dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}
