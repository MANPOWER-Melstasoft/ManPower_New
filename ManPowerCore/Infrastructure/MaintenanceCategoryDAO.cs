using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface MaintenanceCategoryDAO
    {
        List<MaintenanceCategory> GetAllMaintenanceCategory(DBConnection dbConnection);

        MaintenanceCategory GetMaintenanceCategory(int id, DBConnection dbConnection);
    }

    public class MaintenanceCategoryDAOImpl : MaintenanceCategoryDAO
    {
        public List<MaintenanceCategory> GetAllMaintenanceCategory(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM MAINTENANCE_CATEGORY";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<MaintenanceCategory>(dbConnection.dr);

        }

        public MaintenanceCategory GetMaintenanceCategory(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM MAINTENANCE_CATEGORY WHERE Id = " + id + ";";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<MaintenanceCategory>(dbConnection.dr);

        }
    }
}
