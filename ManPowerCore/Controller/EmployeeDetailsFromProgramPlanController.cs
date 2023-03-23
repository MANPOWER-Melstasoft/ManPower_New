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
    public interface EmployeeDetailsFromProgramPlanController
    {
        List<EmployeeDetailsFromProgramPlan> GetAllEmployeeDetailsFromProgramPlans();

        EmployeeDetailsFromProgramPlan GetAllEmployeeDetailsFromProgramPlansByProgramPlanId(int ProgramPlanId);
    }
    public class EmployeeDetailsFromProgramPlanImpl : EmployeeDetailsFromProgramPlanController
    {
        DBConnection dbConnection;
        EmployeeDetailsFromProgramPlanDAO employeeDetailsFromProgramPlanDAO = DAOFactory.CreateemployeeDetailsFromProgramPlanDAO();
        public List<EmployeeDetailsFromProgramPlan> GetAllEmployeeDetailsFromProgramPlans()
        {
            try
            {
                dbConnection = new DBConnection();
                return employeeDetailsFromProgramPlanDAO.GetAllEmployeeDetailsFromProgramPlans(dbConnection);
            }

            catch (Exception)
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

        public EmployeeDetailsFromProgramPlan GetAllEmployeeDetailsFromProgramPlansByProgramPlanId(int ProgramPlanId)
        {
            try
            {
                dbConnection = new DBConnection();
                return employeeDetailsFromProgramPlanDAO.GetAllEmployeeDetailsFromProgramPlansByProgramPlanId(dbConnection, ProgramPlanId);
            }

            catch (Exception)
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
