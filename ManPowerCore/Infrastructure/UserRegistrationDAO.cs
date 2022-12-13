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
    public interface UserRegistrationDAO
    {
        int Save(UserRegistation userRegistation, DBConnection dbConnection);

        int Update(UserRegistation userRegistation, DBConnection dbConnection);

        List<UserRegistation> GetUserLoginList(DBConnection dbConnection);

        UserRegistation GetUserLogin(DBConnection dbConnection, UserRegistation userLogin);
    }

    public class UserRegistrationDAOSqlImpl : UserRegistrationDAO
    {
        public int Save(UserRegistation userRegistation, DBConnection dbConnection)
        {

            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO User_Registation (Designation, Date, Name, Contact_Number, Email, User_Name, Password_2) " +
                                           "values (@Designation, @Date, @Name, @ContactNumber, @Email, @UserName, @Password) SELECT SCOPE_IDENTITY() ";

            dbConnection.cmd.Parameters.AddWithValue("@Designation", userRegistation.Designation);
            dbConnection.cmd.Parameters.AddWithValue("@Date", userRegistation.Date);
            dbConnection.cmd.Parameters.AddWithValue("@Name", userRegistation.Name);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", userRegistation.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Email", userRegistation.Email);
            dbConnection.cmd.Parameters.AddWithValue("@UserName", userRegistation.UserName);
            dbConnection.cmd.Parameters.AddWithValue("@Password", userRegistation.Password);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(UserRegistation userRegistation, DBConnection dbConnection)
        {

            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE User_Registation SET Designation = @Designation, Date = @Date, Name= @Name, " +
                "Contact_Number = @ContactNumber, Email = @Email, User_Name = @UserName, Password_2 = @Password WHERE ID = @UserId ";

            dbConnection.cmd.Parameters.AddWithValue("@UserId", userRegistation.UserId);
            dbConnection.cmd.Parameters.AddWithValue("@Designation", userRegistation.Designation);
            dbConnection.cmd.Parameters.AddWithValue("@Date", userRegistation.Date);
            dbConnection.cmd.Parameters.AddWithValue("@Name", userRegistation.Name);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", userRegistation.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Email", userRegistation.Email);
            dbConnection.cmd.Parameters.AddWithValue("@UserName", userRegistation.UserName);
            dbConnection.cmd.Parameters.AddWithValue("@Password", userRegistation.Password);

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public List<UserRegistation> GetUserLoginList(DBConnection dbConnection)
        {
            List<UserRegistation> userRegistationList = new List<UserRegistation>();

            //if (with0)
            dbConnection.cmd.CommandText = "SELECT * FROM User_Registation";
            //else
            //    dbConnection.cmd.CommandText = "SELECT * FROM User_Registation WHERE is_active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            userRegistationList = dataAccessObject.ReadCollection<UserRegistation>(dbConnection.dr);
            dbConnection.dr.Close();

            return userRegistationList;
        }

        public UserRegistation GetUserLogin(DBConnection dbConnection, UserRegistation userRegistation)
        {

            dbConnection.cmd.CommandText = "SELECT * FROM User_Registation WHERE User_Name = @UserName AND Password_2 = @Password ";

            dbConnection.cmd.Parameters.AddWithValue("@UserName", userRegistation.UserName);
            dbConnection.cmd.Parameters.AddWithValue("@Password", userRegistation.Password);

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            userRegistation = dataAccessObject.GetSingleOject<UserRegistation>(dbConnection.dr);
            dbConnection.dr.Close();

            return userRegistation;
        }
    }
}
