using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ManPowerCore.Controller
{
    public interface UserRegistrationController
    {
        int Save(UserRegistation UserRegistation);

        int Update(UserRegistation UserRegistation);

        List<UserRegistation> GetUserLoginList();

        UserRegistation GetUserLogin(UserRegistation userLUserRegistationogin);
    }

    public class UserRegistrationControllerSqlImpl : UserRegistrationController
    {

        UserRegistrationDAO userRegistrationDAO = DAOFactory.CreateUserRegistrationDAO();

        public int Save(UserRegistation userRegistation)
        {
            DBConnection dbconnection = null;
            try
            {
                dbconnection = new DBConnection();
                return userRegistrationDAO.Save(userRegistation, dbconnection);
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("500.aspx");
                dbconnection.RollBack();
                throw;
            }
            finally
            {
                if (dbconnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbconnection.Commit();
                }
            }
        }

        public int Update(UserRegistation userRegistation)
        {
            DBConnection dbconnection = null;
            try
            {
                dbconnection = new DBConnection();
                return userRegistrationDAO.Update(userRegistation, dbconnection);
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("500.aspx");
                dbconnection.RollBack();
                throw;
            }
            finally
            {
                if (dbconnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbconnection.Commit();
                }
            }
        }

        public List<UserRegistation> GetUserLoginList()
        {
            DBConnection dbConnection = null;
            List<UserRegistation> listuserRegistation = new List<UserRegistation>();
            try
            {
                dbConnection = new DBConnection();
                listuserRegistation = userRegistrationDAO.GetUserLoginList(dbConnection);

            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("500.aspx");
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return listuserRegistation;
        }

        public UserRegistation GetUserLogin(UserRegistation userRegistation)
        {
            DBConnection dbConnection = null;

            try
            {
                dbConnection = new DBConnection();
                userRegistation = userRegistrationDAO.GetUserLogin(dbConnection, userRegistation);

            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("500.aspx");
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return userRegistation;
        }
    }
}
