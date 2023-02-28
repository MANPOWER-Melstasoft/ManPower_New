using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AutUserFunctionDAO
    {
        int Save(AutUserFunction autUserFunction, DBConnection dbConnection);
        int Delete(AutUserFunction autUserFunction, DBConnection dbConnection);
        List<AutUserFunction> GetAllAutUserFunctionByUserId(int AutUserId, DBConnection dbConnection);
        List<AutUserFunction> GetAllAutUserFunction(DBConnection dbConnection);
        AutUserFunction GetAutUserFunction(AutUserFunction autUserFunction, DBConnection dbConnection);

        List<AutUserFunction> GetAutUserFunctionCheckByAll(int function, int userType, DBConnection dbConnection);
        List<AutUserFunction> GetAutUserFunctionAllUserGroupBy(int userType, DBConnection dbConnection);


    }

    public class AutUserFunctionDAOSqlImpl : AutUserFunctionDAO
    {
        public int Save(AutUserFunction autUserFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO aut_user_function VALUES (@AutFunctionId, @AutUserId) ";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autUserFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autUserFunction.AutUserId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int Delete(AutUserFunction autUserFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "DELETE FROM aut_user_function WHERE aut_function_id = @AutFunctionId AND aut_user_id = @AutUserId";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autUserFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autUserFunction.AutUserId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<AutUserFunction> GetAllAutUserFunctionByUserId(int AutUserId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM aut_user_function WHERE aut_user_id = " + AutUserId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<AutUserFunction>(dbConnection.dr);
        }

        public List<AutUserFunction> GetAllAutUserFunction(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM aut_user_function";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<AutUserFunction>(dbConnection.dr);
        }

        public AutUserFunction GetAutUserFunction(AutUserFunction autUserFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM aut_user_function WHERE aut_user_id = @AutUserId AND aut_function_id = @AutFunctionId";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autUserFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autUserFunction.AutUserId);

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<AutUserFunction>(dbConnection.dr);
        }

        public List<AutUserFunction> GetAutUserFunctionCheckByAll(int function, int userType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT uf.aut_user_id, uf.aut_function_id FROM aut_user_function uf " +
                "LEFT JOIN Company_User cu ON cu.Id = uf.aut_user_id WHERE uf.aut_function_id = @FunctionId AND cu.User_Type_Id = @UserTypeId " +
                "GROUP BY uf.aut_user_id, cu.User_Type_Id, uf.aut_function_id;";

            dbConnection.cmd.Parameters.AddWithValue("@FunctionId", function);
            //dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autUserFunction.AutUserId);
            dbConnection.cmd.Parameters.AddWithValue("@UserTypeId", userType);

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<AutUserFunction>(dbConnection.dr);
        }

        public List<AutUserFunction> GetAutUserFunctionAllUserGroupBy(int userType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();

            dbConnection.cmd.CommandText = "SELECT uf.aut_user_id FROM aut_user_function uf LEFT JOIN Company_User cu ON cu.Id = uf.aut_user_id " +
                "WHERE cu.User_Type_Id = @userType GROUP BY uf.aut_user_id; ";

            dbConnection.cmd.Parameters.AddWithValue("@userType", userType);
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<AutUserFunction>(dbConnection.dr);
        }
    }
}
