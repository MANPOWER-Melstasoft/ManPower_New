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
    public interface VehicleMaintenanceController
    {
        int SaveVehicleMeintenance(VehicleMeintenance vehicleMeintenance);

        int UpdateApprovalStatus(int id, int approvalStatus, int officerID, string reason);

        int UpdateRecommandationStatus(int id, int approvalStatus, int officerID, string reason);
        int UpdateRecommandationStatus(int id, int approvalStatus, string FileNo, int officerID, string reason);

        List<VehicleMeintenance> GetAllVehicleMeintenance();
    }

    public class VehicleMaintenanceControllerImpl : VehicleMaintenanceController
    {
        DBConnection dBConnection;
        VehicleMaintenanceDAO vehicleMaintenanceDAO = DAOFactory.CreateVehicleMaintenanceDAO();


        public int SaveVehicleMeintenance(VehicleMeintenance vehicleMeintenance)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = vehicleMaintenanceDAO.SaveVehicleMeintenance(vehicleMeintenance, dBConnection);
                return result;
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

        public int UpdateApprovalStatus(int id, int approvalStatus, int officerID, string reason)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = vehicleMaintenanceDAO.UpdateApprovals(id, approvalStatus, officerID, reason, dBConnection);
                return result;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateRecommandationStatus(int id, int approvalStatus, int officerID, string reason)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = vehicleMaintenanceDAO.UpdateRecommandationStatus(id, approvalStatus, officerID, reason, dBConnection);
                return result;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateRecommandationStatus(int id, int approvalStatus, string FileNo, int officerID, string reason)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = vehicleMaintenanceDAO.UpdateRecommandationADStatus(id, approvalStatus, FileNo, officerID, reason, dBConnection);
                return result;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
        public List<VehicleMeintenance> GetAllVehicleMeintenance()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                List<VehicleMeintenance> vehicleMeintenanceList = vehicleMaintenanceDAO.GetAllVehicleMeintenance(dbConnection);

                EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
                List<Employee> employeeList = employeeController.GetAllEmployees();

                foreach (var item in vehicleMeintenanceList)
                {
                    item.Employee = employeeList.Where(x => x.EmployeeId == item.EmpId).Single();
                }

                return vehicleMeintenanceList;
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
