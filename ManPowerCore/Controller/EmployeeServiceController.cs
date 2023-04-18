using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface EmployeeServiceController
    {
        int SaveEmployeeServices(EmployeeServices empServices);

        EmployeeServices GetEmployeeServicesByEmpId(int empId);
    }

    public class EmployeeServiceControllerImpl : EmployeeServiceController
    {
        DBConnection dBConnection;
        EmployeeServicesDAO emp = DAOFactory.CreateEmployeeServicesDAO();

        public EmployeeServices GetEmployeeServicesByEmpId(int empId)
        {
            try
            {
                dBConnection = new DBConnection();
                return emp.GetEmployeeServicesByEmpId(empId, dBConnection);

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

        public int SaveEmployeeServices(EmployeeServices empServices)
        {

            try
            {
                dBConnection = new DBConnection();
                emp.SaveEmployeeServices(empServices, dBConnection);
                return 1;
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
