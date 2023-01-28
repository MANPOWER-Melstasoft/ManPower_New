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
    public interface EmergencyContactController
    {
        int SaveEmergencyContact(EmergencyContact emergencyContact);

        List<EmergencyContact> GetAllEmergencyContact();

        EmergencyContact GetEmergencyContactById(int id);

        int UpdateEmergencyContact(EmergencyContact emergencyContact);
    }

    public class EmergencyContactControllerImpl : EmergencyContactController
    {
        DBConnection dBConnection;
        EmergencyContactDAO eContact = DAOFactory.CreateEmergencyContactDAO();


        public int SaveEmergencyContact(EmergencyContact emergencyContact)
        {

            try
            {
                dBConnection = new DBConnection();
                eContact.SaveEmergencyContact(emergencyContact, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateEmergencyContact(EmergencyContact emergencyContact)
        {


            try
            {
                dBConnection = new DBConnection();
                eContact.UpdateEmergencyContact(emergencyContact, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }


        public List<EmergencyContact> GetAllEmergencyContact()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                EmergencyContactDAO DAO = DAOFactory.CreateEmergencyContactDAO();
                List<EmergencyContact> list = DAO.GetAllEmergencyContact(dBConnection);
                return list;
            }

            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }

            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public EmergencyContact GetEmergencyContactById(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {

                EmergencyContactDAO DAO = DAOFactory.CreateEmergencyContactDAO();

                EmergencyContact emp = DAO.GetEmergencyContactById(id, dbConnection);

                return emp;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                return null;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}

