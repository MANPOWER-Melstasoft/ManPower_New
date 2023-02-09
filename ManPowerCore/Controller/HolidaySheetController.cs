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
    public interface HolidaySheetController
    {
        int save(HolidaySheet holidaySheet);

        List<HolidaySheet> getAllHolidays();
    }
    public class HolidaySheetControllerImpl : HolidaySheetController
    {
        DBConnection dBConnection;
        HolidaySheetDAO HolidaySheetDAO = DAOFactory.CreateHolidaySheetDAO();

        public int save(HolidaySheet holidaySheet)
        {
            try
            {
                dBConnection = new DBConnection();
                return HolidaySheetDAO.save(holidaySheet, dBConnection);

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

        public List<HolidaySheet> getAllHolidays()
        {
            try
            {
                dBConnection = new DBConnection();
                return HolidaySheetDAO.getAllHolidays(dBConnection);

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
