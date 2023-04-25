using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface IndividualBeneReportDAO
    {
        List<IndividualBeneReport> GetReport(DBConnection dbConnection);
    }

    public class IndividualBeneReportDAOSqlImpl : IndividualBeneReportDAO
    {
        public List<IndividualBeneReport> GetReport(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ib.Id, ib.Nic, ib.Name, ib.Gender, ib.Date_of_Birth, ib.Personal_Address, ib.Email, " +
                "ib.Job_preference, ib.Contact_Number, ib.Whatsapp_Number, ib.Is_in_School, " +
                "ib.School_Name, ib.Address_of_School, ib.Grade, ib.Parent_Nic, " +
                "ctr.Career_Key_Test_Id, ctr.R, ctr.I, ctr.A, ctr.S, ctr.E, ctr.C, ctr.Provided_Guidance, " +
                "ctr.Career_Key_Test_Held_Date, ctr.Career_Key_Test_Program_Plan," +
                "tr.Training_Refferals_Id, tr.Institute_Name, tr.Training_Course, tr.Contact_Person_Name, " +
                "tr.Training_Refferals_Date, tr.Training_Refferals_Program_Plan," +
                "jr.Job_Refferals_Id, cvrd.Company_Name, cvrd.Career_Path, cvrd.Job_Position, jr.Career_Guidance, jr.Remarks, " +
                "jr.Job_Refferals_Date, jr.Job_Placement_Date, jr.Job_Refferals_Program_Plan " +
                "FROM Induvidual_Beneficiary ib " +
                "LEFT JOIN (SELECT ctr.Id AS Career_Key_Test_Id, ctr.Beneficiary_Id, R, I, A, S, E, C, Provided_Guidance, " +
                "Held_Date AS Career_Key_Test_Held_Date, ctr.Is_Active, ProgramName AS Career_Key_Test_Program_Plan " +
                "FROM Career_Key_Test_Results ctr " +
                "LEFT JOIN Program_Plan pl ON pl.Id = ctr.Program_Plan_Id WHERE ctr.Is_Active = 1 " +
                "GROUP BY ctr.Id, ctr.Beneficiary_Id, R, I, A, S, E, C, Provided_Guidance, Held_Date, ctr.Is_Active, ProgramName) " +
                "ctr ON ctr.Beneficiary_Id = ib.Id " +
                "LEFT JOIN (SELECT tr.Id AS Training_Refferals_Id, tr.Beneficiary_Id, Institute_Name, Training_Course, Contact_Person_Name, " +
                "Refferals_Date AS Training_Refferals_Date, tr.Is_Active, ProgramName AS Training_Refferals_Program_Plan " +
                "FROM Training_Refferals tr " +
                "LEFT JOIN Program_Plan pl ON pl.Id = tr.Program_Plan_Id WHERE tr.Is_Active = 1 " +
                "GROUP BY tr.Id, tr.Beneficiary_Id, Institute_Name, Training_Course, Contact_Person_Name, Refferals_Date, tr.Is_Active, ProgramName) " +
                "tr ON tr.Beneficiary_Id = ib.Id " +
                "LEFT JOIN (SELECT jr.Id AS Job_Refferals_Id, jr.Beneficiary_Id, Company_Vacancy_Resgistration_Id, Job_Category_Id, Job_Refferals_Date, " +
                "Job_Placement_Date, Career_Guidance, Remarks, Is_Active, ProgramName AS Job_Refferals_Program_Plan FROM Job_Refferals jr " +
                "LEFT JOIN Program_Plan pl ON pl.Id = jr.Program_Plan_Id WHERE jr.Is_Active = 1 " +
                "GROUP BY jr.Id, jr.Beneficiary_Id, Company_Vacancy_Resgistration_Id, Job_Category_Id, Job_Refferals_Date, " +
                "Job_Placement_Date, Career_Guidance, Remarks, Is_Active, ProgramName) " +
                "jr ON jr.Beneficiary_Id = ib.Id " +
                "LEFT JOIN Company_vacancy_Registation_Details cvrd ON jr.Company_Vacancy_Resgistration_Id = cvrd.ID " +
                "WHERE ib.Is_Active = 1 GROUP BY ib.Id, ib.Nic, ib.Name, ib.Gender, ib.Date_of_Birth, ib.Personal_Address, ib.Email, " +
                "ib.Job_preference, ib.Contact_Number, ib.Whatsapp_Number, ib.Is_in_School, " +
                "ib.School_Name, ib.Address_of_School, ib.Grade, ib.Parent_Nic, " +
                "ctr.Career_Key_Test_Id, ctr.R, ctr.I, ctr.A, ctr.S, ctr.E, ctr.C, ctr.Provided_Guidance, " +
                "ctr.Career_Key_Test_Held_Date, ctr.Career_Key_Test_Program_Plan, " +
                "tr.Training_Refferals_Id, tr.Institute_Name, tr.Training_Course, tr.Contact_Person_Name, " +
                "tr.Training_Refferals_Date, tr.Training_Refferals_Program_Plan, " +
                "jr.Job_Refferals_Id, cvrd.Company_Name, cvrd.Career_Path, cvrd.Job_Position, jr.Career_Guidance, jr.Remarks, " +
                "jr.Job_Refferals_Date, jr.Job_Placement_Date, jr.Job_Refferals_Program_Plan;";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<IndividualBeneReport>(dbConnection.dr);
        }
    }
}
