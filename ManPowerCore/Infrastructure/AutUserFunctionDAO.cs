using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AutUserFunctionDAO
    {
        int Save(AutUserFunction autUserFunction, DBConnection dbConnection);
        int Delete(AutUserFunction autUserFunction, DBConnection dbConnection);
        List<AutUserFunction> GetAllAutUserFunctionByUserId(int AutUserId, DBConnection dbConnection);
        List<AutUserFunction> GetAllAutUserFunction(DBConnection dbConnection);
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

    }
}
