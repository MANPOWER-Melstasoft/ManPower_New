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
    public interface VacancyPositionController
    {
        int saveVacancyPosition(VacancyPosition vacancyPosition);
        int updateVacancyPosition(int id, VacancyPosition vacancyPosition);
        List<VacancyPosition> getVacancyPositionList();
        int deletePosition(int id);

    }
    public class VacancyPositionControllerImpl : VacancyPositionController
    {
        DBConnection dBConnection;
        VacancyPositionDAO vacancyPositionDAO = DAOFactory.CreateVacancyPositionDAO();
        public int saveVacancyPosition(VacancyPosition vacancyPosition)
        {
            try
            {
                dBConnection = new DBConnection();
                return vacancyPositionDAO.saveVacancyPosition(vacancyPosition, dBConnection);
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

        public List<VacancyPosition> getVacancyPositionList()
        {
            try
            {
                dBConnection = new DBConnection();
                return vacancyPositionDAO.getAllVacancyPosition(dBConnection);
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

        public int updateVacancyPosition(int id, VacancyPosition vacancyPosition)
        {
            try
            {
                dBConnection = new DBConnection();
                return vacancyPositionDAO.updateVacancyPosition(id, vacancyPosition, dBConnection);
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

        public int deletePosition(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return vacancyPositionDAO.deletePosition(id, dBConnection);
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
