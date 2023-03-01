using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AutFunctionDAO
    {
        List<AutFunction> GetAllAutFunctionById(int AutFunctionId, DBConnection dbConnection);
        List<AutFunction> GetAllAutFunction(DBConnection dbConnection);

        int Update(AutFunction autFunction, DBConnection dbConnection);

    }

    public class AutFunctionDAOImpl : AutFunctionDAO
    {
        public List<AutFunction> GetAllAutFunctionById(int AutFunctionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM AUT_FUNCTION where ID = " + AutFunctionId + " ";
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
            {
                DataAccessObject dataAccessObject = new DataAccessObject();
                return dataAccessObject.ReadCollection<AutFunction>(dbConnection.dr);
            }
        }

        public List<AutFunction> GetAllAutFunction(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();
            dbConnection.cmd.CommandText = "SELECT * FROM AUT_FUNCTION";
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
            {
                DataAccessObject dataAccessObject = new DataAccessObject();
                return dataAccessObject.ReadCollection<AutFunction>(dbConnection.dr);
            }
        }

        public int Update(AutFunction autFunction, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE AUT_FUNCTION SET DIVISION = @division, order_number = @OrderNumber, MENU_ICON = @MenuIcon WHERE ID = @AutFunctionId";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@division", autFunction.division);
            dbConnection.cmd.Parameters.AddWithValue("@OrderNumber", autFunction.OrderNumber);
            dbConnection.cmd.Parameters.AddWithValue("@MenuIcon", autFunction.MenuIcon);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

    }

}

