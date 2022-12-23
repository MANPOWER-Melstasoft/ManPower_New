using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface ReportController
    {
        DataTable GetLeaveBalance();
    }
    public class ReportControllerImpl : ReportController
    {
        List<Report> reportsCasual = new List<Report>();
        List<Report> reportsMedical = new List<Report>();
        List<Report> reportsSpecial = new List<Report>();
        List<Report> reportsShort = new List<Report>();
        List<Report> reportsDuty = new List<Report>();
        List<Report> reportsLeaveTo = new List<Report>();

        List<Report> reportsAllType = new List<Report>();
        List<Report> reportListTable = new List<Report>();

        List<Report> reportFinal = new List<Report>();

        public DataTable GetLeaveBalance()
        {

            DBConnection dbConnection = null;
            DataTable tableLeave = new DataTable();
            ReportDAO reportDAO = DAOFactory.CreateReportDAO();
            try
            {
                dbConnection = new DBConnection();
                tableLeave = reportDAO.GetLeaveBalance(dbConnection);

                foreach (DataRow row in tableLeave.Rows)
                {
                    Report report = new Report();



                    if (row["Approved_By"].ToString() != "")
                    {

                        report.ApprovedLeaves = Convert.ToInt32(row["Approved_By"]);
                    }
                    else
                    {
                        report.ApprovedLeaves = 0;
                    }

                    report.Entitlement = row["Entitlement"].ToString();
                    report.LeaveType = row["Leave_Type_id"].ToString();

                    report.NoOfDays = Convert.ToInt32(row["No_Of_Days"]);

                    reportsAllType.Add(report);

                }

                reportsCasual = reportsAllType.Where(x => x.LeaveType == "1").ToList();

                reportsMedical = reportsAllType.Where(x => x.LeaveType == "2").ToList();

                int countCasual = 0;
                int countMedical = 0;
                int pendingApproval = 0;

                if (reportsCasual.Count > 0)
                {
                    foreach (var item in reportsCasual)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countCasual += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report1 = new Report();
                    report1.ApprovedLeaves = countCasual;
                    report1.PendingApproval = pendingApproval;
                    report1.Entitlement = reportsCasual[0].Entitlement;
                    report1.LeaveBalannce = Convert.ToInt32(report1.Entitlement) - report1.ApprovedLeaves;
                    report1.LeaveType = "Casual";

                    reportFinal.Add(report1);


                }

                //if (reportsMedical.Count > 0)
                //{
                //    pendingApproval = 0;
                //    foreach (var item in reportsMedical)
                //    {
                //        if (item.ApprovedLeaves != 0)
                //        {

                //            countMedical += item.NoOfDays;
                //        }
                //        if (item.ApprovedLeaves == 0)
                //        {
                //            pendingApproval += item.NoOfDays;
                //        }

                //    }

                //    Report report2 = new Report();
                //    report2.ApprovedLeaves = countCasual;
                //    report2.PendingApproval = pendingApproval;
                //    report2.Entitlement = reportsMedical[0].Entitlement;
                //    report2.LeaveBalannce = Convert.ToInt32(report2.Entitlement) - report2.ApprovedLeaves;
                //    report2.LeaveType = "Casual";

                //    reportFinal.Add(report2);


                //}



            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return tableLeave;
        }
    }
}
