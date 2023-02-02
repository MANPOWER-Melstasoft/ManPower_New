using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManPowerCore.Common;

namespace ManPowerCore.Domain
{
    public interface DistrictTASummaryDAO
    {
        List<DistrictTASummary> GetDistrictTASummaryReport(DBConnection dbConnection);
    }
    public class DistrictTASummaryDAOImpl : DistrictTASummaryDAO
    {
        public List<DistrictTASummary> GetDistrictTASummaryReport(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT b.name, a.id AS Target_ID, c.Id AS Plan_ID, " +
                "b.Program_Type_Id, SUM(a.No_Of_Projects) AS Projects, " +
                "d.count, c.Male_Count+c.Female_Count AS No_of_Beneficiaries, j.Name AS Locations " +
                "FROM Program_Target a INNER JOIN Program b ON a.Program_Id = b.id " +
                "LEFT JOIN Program_Plan c ON a.id = c.Program_Target_Id " +
                "LEFT JOIN (SELECT Program_Target_Id, COUNT(Program_Target_Id) AS count " +
                "FROM Program_Plan where program_Plan.Project_Status_id =4 " +
                "GROUP BY Program_Target_Id) d ON a.id = d.Program_Target_Id " +
                "INNER JOIN (select Department_Unit_Possitions_Id, Program_Target_Id, Department_Unit_Id, " +
                "Name from program_Assignee f INNER JOIN Program_Target g ON g.Id = f.Program_Target_Id " +
                "INNER JOIN Department_Unit_Possitions h ON h.id = f.Department_Unit_Possitions_Id " +
                "INNER JOIN department_Unit i ON i.id = h.department_UNit_Id " +
                "group by Program_Target_Id, Department_Unit_Possitions_Id, Department_Unit_Id, name) j" +
                " ON j.program_target_id = c.Program_Target_Id where c.project_status_id = 4 " +
                "GROUP BY a.Program_Id, b.name, a.id, c.Id, b.Program_Type_Id, d.count, c.Male_Count, c.Female_Count, j.Name " +
                "order by Locations;";


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DistrictTASummary>(dbConnection.dr);
        }
    }
}
