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
    public interface IndividualBeneReportController
    {
        List<IndividualBeneReport> GetReport();
    }

    public class IndividualBeneReportControllerSqlImpl : IndividualBeneReportController
    {
        IndividualBeneReportDAO IndividualBeneReportDAO = DAOFactory.createIndividualBeneReportDAO();
        DBConnection dBConnection;

        public List<IndividualBeneReport> GetReport()
        {
            try
            {
                dBConnection = new DBConnection();
                return IndividualBeneReportDAO.GetReport(dBConnection);
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
