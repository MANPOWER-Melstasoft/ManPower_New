using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AutSystemRoleFunctionDAO
    {
        int Save(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection);
        int Delete(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection);
        List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId, DBConnection dbConnection);
        AutSystemRoleFunction GetAutSystemRoleFunction(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection);
    }

    public class AutSystemRoleFunctionDAOImpl : AutSystemRoleFunctionDAO
    {

        public int Save(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO AUT_SYSTEM_ROLE_FUNCTION VALUES (1, @AutUserId, @AutFunctionId) ";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autSystemRoleFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autSystemRoleFunction.UserTypeId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int Delete(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "DELETE FROM AUT_SYSTEM_ROLE_FUNCTION WHERE aut_function_id = @AutFunctionId AND USER_Type_ID = @AutUserId";

            dbConnection.cmd.Parameters.AddWithValue("@AutFunctionId", autSystemRoleFunction.AutFunctionId);
            dbConnection.cmd.Parameters.AddWithValue("@AutUserId", autSystemRoleFunction.UserTypeId);

            return dbConnection.cmd.ExecuteNonQuery();
        }


        public List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM AUT_SYSTEM_ROLE_FUNCTION where USER_Type_ID = " + UserTypeId + " and AUT_SYSTEM_ID = 1 ";
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
            {
                DataAccessObject dataAccessObject = new DataAccessObject();
                return dataAccessObject.ReadCollection<AutSystemRoleFunction>(dbConnection.dr);
            }
        }

        public AutSystemRoleFunction GetAutSystemRoleFunction(AutSystemRoleFunction autSystemRoleFunction, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM aut_system_role_function WHERE User_Type_Id = " + autSystemRoleFunction.UserTypeId +
                " AND aut_function_id = " + autSystemRoleFunction.AutFunctionId + " AND aut_system_id = 1 ";

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
            {
                DataAccessObject dataAccessObject = new DataAccessObject();
                return dataAccessObject.GetSingleOject<AutSystemRoleFunction>(dbConnection.dr);
            }
        }
    }
}
