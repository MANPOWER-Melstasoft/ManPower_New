using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface OfficerListDAO
    {
        DataTable getOfficerList(DBConnection dBConnection);
    }
    public class OfficerListDAOSqlImpl : OfficerListDAO
    {
        public DataTable getOfficerList(DBConnection dBConnection)
        {
            DataTable TabaleOfficer = new DataTable();


            dBConnection.cmd.CommandText = "Select Company_User.Name,Company_User.Id,Company_User.User_Type_Id,Department_Unit_Possitions.Possitions_Id,Department_Unit_Possitions.Department_Unit_Id,Department_Unit.Parent_Id From Company_User INNER JOIN Department_Unit_Possitions ON Company_User.Id=Department_Unit_Possitions.System_User_Id INNER JOIN Department_Unit ON Department_Unit.Id=Department_Unit_Possitions.Department_Unit_Id;";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(dBConnection.cmd);
            dataAdapter.Fill(TabaleOfficer);

            return TabaleOfficer;

        }
    }
}
