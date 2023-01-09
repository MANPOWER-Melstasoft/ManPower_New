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
        List<Report> GetLeaveBalance();

        List<Report> GetLeaveBalanceByEmployeeId(int EmployeId);
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



        public List<Report> GetLeaveBalance()
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
                    report.EmployeeId = Convert.ToInt32(row["Employee_ID"]);

                    reportsAllType.Add(report);

                }

                reportsCasual = reportsAllType.Where(x => x.LeaveType == "1").ToList();
                reportsMedical = reportsAllType.Where(x => x.LeaveType == "2").ToList();
                reportsSpecial = reportsAllType.Where(x => x.LeaveType == "3").ToList();
                reportsShort = reportsAllType.Where(x => x.LeaveType == "4").ToList();
                reportsDuty = reportsAllType.Where(x => x.LeaveType == "5").ToList();
                reportsLeaveTo = reportsAllType.Where(x => x.LeaveType == "6").ToList();

                int countCasual = 0;
                int countMedical = 0;
                int countSpecial = 0;
                int countShort = 0;
                int countDuty = 0;
                int countLeaveTo = 0;

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
                    report1.EmployeeId = reportsCasual[0].EmployeeId;

                    reportFinal.Add(report1);


                }

                if (reportsMedical.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsMedical)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countMedical += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report2 = new Report();
                    report2.ApprovedLeaves = countCasual;
                    report2.PendingApproval = pendingApproval;
                    report2.Entitlement = reportsMedical[0].Entitlement;
                    report2.LeaveBalannce = Convert.ToInt32(report2.Entitlement) - report2.ApprovedLeaves;
                    report2.LeaveType = "Medical";
                    report2.EmployeeId = reportsMedical[0].EmployeeId;

                    reportFinal.Add(report2);


                }

                if (reportsSpecial.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsSpecial)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countSpecial += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report3 = new Report();
                    report3.ApprovedLeaves = countSpecial;
                    report3.PendingApproval = pendingApproval;
                    report3.Entitlement = reportsSpecial[0].Entitlement;
                    report3.LeaveBalannce = Convert.ToInt32(report3.Entitlement) - report3.ApprovedLeaves;
                    report3.LeaveType = "Special";
                    report3.EmployeeId = reportsSpecial[0].EmployeeId;

                    reportFinal.Add(report3);


                }

                if (reportsShort.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsShort)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countShort += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report4 = new Report();
                    report4.ApprovedLeaves = countShort;
                    report4.PendingApproval = pendingApproval;
                    report4.Entitlement = reportsShort[0].Entitlement;
                    report4.LeaveBalannce = Convert.ToInt32(report4.Entitlement) - report4.ApprovedLeaves;
                    report4.LeaveType = "Special";
                    report4.EmployeeId = reportsShort[0].EmployeeId;

                    reportFinal.Add(report4);


                }

                if (reportsDuty.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsDuty)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countDuty += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report5 = new Report();
                    report5.ApprovedLeaves = countDuty;
                    report5.PendingApproval = pendingApproval;
                    report5.Entitlement = reportsDuty[0].Entitlement;
                    report5.LeaveBalannce = Convert.ToInt32(report5.Entitlement) - report5.ApprovedLeaves;
                    report5.LeaveType = "Duty";
                    report5.EmployeeId = reportsDuty[0].EmployeeId;

                    reportFinal.Add(report5);


                }

                if (reportsLeaveTo.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsLeaveTo)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countLeaveTo += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report6 = new Report();
                    report6.ApprovedLeaves = countLeaveTo;
                    report6.PendingApproval = pendingApproval;
                    report6.Entitlement = reportsLeaveTo[0].Entitlement;
                    report6.LeaveBalannce = Convert.ToInt32(report6.Entitlement) - report6.ApprovedLeaves;
                    report6.LeaveType = "Leave To Leave";
                    report6.EmployeeId = reportsLeaveTo[0].EmployeeId;

                    reportFinal.Add(report6);


                }





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
            return reportFinal;
        }

        public List<Report> GetLeaveBalanceByEmployeeId(int EmployeId)
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

                    report.NoOfDays = Convert.ToInt32(row["No_Of_Leave"]);
                    report.EmployeeId = Convert.ToInt32(row["Employee_ID"]);

                    reportsAllType.Add(report);

                }

                reportsCasual = reportsAllType.Where(x => x.LeaveType == "1" && x.EmployeeId == EmployeId).ToList();
                reportsMedical = reportsAllType.Where(x => x.LeaveType == "2" && x.EmployeeId == EmployeId).ToList();
                reportsSpecial = reportsAllType.Where(x => x.LeaveType == "3" && x.EmployeeId == EmployeId).ToList();
                reportsShort = reportsAllType.Where(x => x.LeaveType == "4" && x.EmployeeId == EmployeId).ToList();
                reportsDuty = reportsAllType.Where(x => x.LeaveType == "5" && x.EmployeeId == EmployeId).ToList();
                reportsLeaveTo = reportsAllType.Where(x => x.LeaveType == "6" && x.EmployeeId == EmployeId).ToList();

                int countCasual = 0;
                int countMedical = 0;
                int countSpecial = 0;
                int countShort = 0;
                int countDuty = 0;
                int countLeaveTo = 0;

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

                if (reportsMedical.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsMedical)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countMedical += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report2 = new Report();
                    report2.ApprovedLeaves = countCasual;
                    report2.PendingApproval = pendingApproval;
                    report2.Entitlement = reportsMedical[0].Entitlement;
                    report2.LeaveBalannce = Convert.ToInt32(report2.Entitlement) - report2.ApprovedLeaves;
                    report2.LeaveType = "Medical";

                    reportFinal.Add(report2);


                }

                if (reportsSpecial.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsSpecial)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countSpecial += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report3 = new Report();
                    report3.ApprovedLeaves = countSpecial;
                    report3.PendingApproval = pendingApproval;
                    report3.Entitlement = reportsSpecial[0].Entitlement;
                    report3.LeaveBalannce = Convert.ToInt32(report3.Entitlement) - report3.ApprovedLeaves;
                    report3.LeaveType = "Special";

                    reportFinal.Add(report3);


                }

                if (reportsShort.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsShort)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countShort += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report4 = new Report();
                    report4.ApprovedLeaves = countShort;
                    report4.PendingApproval = pendingApproval;
                    report4.Entitlement = reportsShort[0].Entitlement;
                    report4.LeaveBalannce = Convert.ToInt32(report4.Entitlement) - report4.ApprovedLeaves;
                    report4.LeaveType = "Special";

                    reportFinal.Add(report4);


                }

                if (reportsDuty.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsDuty)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countDuty += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report5 = new Report();
                    report5.ApprovedLeaves = countDuty;
                    report5.PendingApproval = pendingApproval;
                    report5.Entitlement = reportsDuty[0].Entitlement;
                    report5.LeaveBalannce = Convert.ToInt32(report5.Entitlement) - report5.ApprovedLeaves;
                    report5.LeaveType = "Duty";

                    reportFinal.Add(report5);


                }

                if (reportsLeaveTo.Count > 0)
                {
                    pendingApproval = 0;
                    foreach (var item in reportsLeaveTo)
                    {
                        if (item.ApprovedLeaves != 0)
                        {

                            countLeaveTo += item.NoOfDays;
                        }
                        if (item.ApprovedLeaves == 0)
                        {
                            pendingApproval += item.NoOfDays;
                        }

                    }

                    Report report6 = new Report();
                    report6.ApprovedLeaves = countLeaveTo;
                    report6.PendingApproval = pendingApproval;
                    report6.Entitlement = reportsLeaveTo[0].Entitlement;
                    report6.LeaveBalannce = Convert.ToInt32(report6.Entitlement) - report6.ApprovedLeaves;
                    report6.LeaveType = "Duty";

                    reportFinal.Add(report6);


                }





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
            return reportFinal;
        }
    }
}
