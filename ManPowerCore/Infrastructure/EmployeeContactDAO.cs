using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EmployeeContactDAO
    {
        List<EmployeeContact> GetAllEmployeeContact(DBConnection dbConnection);

        EmployeeContact GetEmployeeContactById(int id, DBConnection dbConnection);

        List<EmployeeContact> GetAllEmployeeContactById(int id,DBConnection dbConnection);

        int SaveEmployeeContact(EmployeeContact empContact, DBConnection dbConnection);

        int UpdateEmployeeContact(EmployeeContact empContact, DBConnection dbConnection);
    }

    public class EmployeeContactDAOImpl : EmployeeContactDAO
    {

        public int SaveEmployeeContact(EmployeeContact empContact, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO EMPLOYEE_CONTACT(EMPLOYEE_ID,ADDRESS,MOBILE_NUMBER,TELEPHONE,EMAIL) " +
                "VALUES(@EmpID,@EmpAddress,@MobileNumber,@EmpTelephone,@EmpEmail)";



            dbConnection.cmd.Parameters.AddWithValue("@EmpID", empContact.EmpID);
            dbConnection.cmd.Parameters.AddWithValue("@EmpAddress", empContact.EmpAddress);
            dbConnection.cmd.Parameters.AddWithValue("@MobileNumber", empContact.MobileNumber);
            dbConnection.cmd.Parameters.AddWithValue("@EmpTelephone", empContact.EmpTelephone);
            dbConnection.cmd.Parameters.AddWithValue("@EmpEmail", empContact.EmpEmail);
            //dbConnection.cmd.Parameters.AddWithValue("@OfficePhone", empContact.OfficePhone);
            //dbConnection.cmd.Parameters.AddWithValue("@PostalCode", empContact.PostalCode);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public int UpdateEmployeeContact(EmployeeContact empContact, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();

            dbConnection.cmd.CommandText = "UPDATE EMPLOYEE_CONTACT SET ADDRESS = @EmpAddress, MOBILE_NUMBER = @MobileNumber, TELEPHONE = @EmpTelephone, OFFICE_PHONE = @OfficePhone," +
                " EMAIL = @EmpEmail, POSTAL_CODE = @PostalCode WHERE EMPLOYEE_ID  = @EmpID ";

            dbConnection.cmd.Parameters.AddWithValue("@EmpID", empContact.EmpID);
            dbConnection.cmd.Parameters.AddWithValue("@EmpAddress", empContact.EmpAddress);
            dbConnection.cmd.Parameters.AddWithValue("@MobileNumber", empContact.MobileNumber);
            dbConnection.cmd.Parameters.AddWithValue("@EmpTelephone", empContact.EmpTelephone);
            dbConnection.cmd.Parameters.AddWithValue("@OfficePhone", empContact.OfficePhone);
            dbConnection.cmd.Parameters.AddWithValue("@EmpEmail", empContact.EmpEmail);
            dbConnection.cmd.Parameters.AddWithValue("@PostalCode", empContact.PostalCode);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public List<EmployeeContact> GetAllEmployeeContact(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<EmployeeContact>(dbConnection.dr);

        }

        public List<EmployeeContact> GetAllEmployeeContactById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT WHERE EMPLOYEE_ID =" + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<EmployeeContact>(dbConnection.dr);
        }

        public EmployeeContact GetEmployeeContactById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT WHERE EMPLOYEE_ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<EmployeeContact>(dbConnection.dr);

        }
    }
}

