using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface HolidaySheetDAO
    {
        int save(HolidaySheet holidaySheet, DBConnection dBConnection);
    }
    public class HolidaySheetDAOImpl : HolidaySheetDAO
    {
        public int save(HolidaySheet holidaySheet, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();



            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Holiday_Sheet(Date,Description) VALUES(@Date,@Desc)";



            dbConnection.cmd.Parameters.AddWithValue("@Desc", holidaySheet.Description);
            dbConnection.cmd.Parameters.AddWithValue("@Date", holidaySheet.HolidayDate);





            return dbConnection.cmd.ExecuteNonQuery();
        }
    }
}
