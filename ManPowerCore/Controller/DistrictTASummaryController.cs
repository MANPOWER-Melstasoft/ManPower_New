using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface DistrictTASummaryController
    {
        List<DistrictTASummaryReport> GetDistrictTASummaryReport();
    }
    public class DistrictTASummaryControllerImpl : DistrictTASummaryController
    {
        DBConnection dBConnection;
        DistrictTASummaryDAO districtTASummaryDAO = DAOFactory.CreateDistrictTASummaryDAO();
        public List<DistrictTASummaryReport> GetDistrictTASummaryReport()
        {
            try
            {
                dBConnection = new DBConnection();
                return districtTASummaryDAO.GetDistrictTASummaryReport(dBConnection);

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
