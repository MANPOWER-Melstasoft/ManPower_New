using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EmergencyContactDAO
    {
        int SaveEmergencyContact(EmergencyContact emergencyContact, DBConnection dbConnection);

        List<EmergencyContact> GetAllEmergencyContact(DBConnection dbConnection);

        EmergencyContact GetEmergencyContactById(int id, DBConnection dbConnection);

        int UpdateEmergencyContact(EmergencyContact emergencyContact, DBConnection dbConnection);
    }

    public class EmergencyContactDAOImpl : EmergencyContactDAO
    {
        public int SaveEmergencyContact(EmergencyContact emergencyContact, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO EMERGENCY_CONTACT(EMPLOYEE_ID,CONTACT_PERSON_NME,DEPENDENT_TYPE_TO_EMPLOYEE,ADDRESS_OF_EMEGENCY_PERSON, " +
                "MOBILE,TELEPHONE,OFFICE_PHONE)" +
                "VALUES(@EmplId,@Name,@DependentToEmployee,@EmgAddress,@EmgTelephone,@EmgMobile,@OfficePhone)";



            dbConnection.cmd.Parameters.AddWithValue("@EmplId", emergencyContact.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", emergencyContact.Name);
            dbConnection.cmd.Parameters.AddWithValue("@DependentToEmployee", emergencyContact.DependentToEmployee);
            dbConnection.cmd.Parameters.AddWithValue("@EmgAddress", emergencyContact.EmgAddress);
            dbConnection.cmd.Parameters.AddWithValue("@EmgTelephone", emergencyContact.EmgTelephone);
            dbConnection.cmd.Parameters.AddWithValue("@EmgMobile", emergencyContact.EmgMobile);
            dbConnection.cmd.Parameters.AddWithValue("@OfficePhone", emergencyContact.OfficePhone);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }

        public int UpdateEmergencyContact(EmergencyContact emergencyContact, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();

            dbConnection.cmd.CommandText = "UPDATE EMERGENCY_CONTACT SET CONTACT_PERSON_NME = @Name, DEPENDENT_TYPE_TO_EMPLOYEE = @DependentToEmployee," +
                "ADDRESS_OF_EMEGENCY_PERSON = @EmgAddress , MOBILE = @EmgMobile, TELEPHONE = @EmgTelephone, OFFICE_PHONE = @OfficePhone" +
                " WHERE ID = @DependantTypeId";


            dbConnection.cmd.Parameters.AddWithValue("@EmplId", emergencyContact.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", emergencyContact.Name);
            dbConnection.cmd.Parameters.AddWithValue("@DependentToEmployee", emergencyContact.DependentToEmployee);
            dbConnection.cmd.Parameters.AddWithValue("@EmgAddress", emergencyContact.EmgAddress);
            dbConnection.cmd.Parameters.AddWithValue("@EmgTelephone", emergencyContact.EmgTelephone);
            dbConnection.cmd.Parameters.AddWithValue("@EmgMobile", emergencyContact.EmgMobile);
            dbConnection.cmd.Parameters.AddWithValue("@OfficePhone", emergencyContact.OfficePhone);
            dbConnection.cmd.Parameters.AddWithValue("@DependantTypeId", emergencyContact.DependantTypeId);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public List<EmergencyContact> GetAllEmergencyContact(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMERGENCY_CONTACT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<EmergencyContact>(dbConnection.dr);

        }

        public EmergencyContact GetEmergencyContactById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMERGENCY_CONTACT WHERE EMPLOYEE_ID=" + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<EmergencyContact>(dbConnection.dr);
        }
    }
}

