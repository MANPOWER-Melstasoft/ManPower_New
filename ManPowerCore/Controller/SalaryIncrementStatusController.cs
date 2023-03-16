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
    public interface SalaryIncrementStatusController
    {
        List<SalaryIncrementStatus> GetAllSalaryIncrementStatus();
    }

    public class SalaryIncrementStatusControllerImpl : SalaryIncrementStatusController
    {
        DBConnection dBConnection;
        SalaryIncrementStatusDAO salaryIncrementStatusDAO = DAOFactory.createSalaryIncrementStatusDAO();
        public List<SalaryIncrementStatus> GetAllSalaryIncrementStatus()
        {
            try
            {
                dBConnection = new DBConnection();
                return salaryIncrementStatusDAO.GetAllSalaryIncrementStatus(dBConnection);
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
