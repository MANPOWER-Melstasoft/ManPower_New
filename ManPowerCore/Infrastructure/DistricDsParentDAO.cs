using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DistricDsParentDAO
    {
        int Save(DistricDsParent districDsParent, DBConnection dbConnection);
        int Update(DistricDsParent districDsParent, DBConnection dbConnection);
        int Delete(DistricDsParent districDsParent, DBConnection dbConnection);
        List<DistricDsParent> GetAllDistricDsParent(DBConnection dbConnection);
        DistricDsParent GetDistricDsParent(DistricDsParent districDsParent, DBConnection dbConnection);
        DistricDsParent GetDistricDsParentFromDep(int id, DBConnection dbConnection);
        DistricDsParent GetDistricDsParentFromId(int id, DBConnection dbConnection);
    }

    public class DistricDsParentDAOSqlImpl : DistricDsParentDAO
    {
        public int Save(DistricDsParent districDsParent, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Distric_Ds_Parent VALUES (@ParentUserId, @DepartmentId) ";

            dbConnection.cmd.Parameters.AddWithValue("@ParentUserId", districDsParent.ParentUserId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentId", districDsParent.DepartmentId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int Update(DistricDsParent districDsParent, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Distric_Ds_Parent SET Parent_User_Id = @ParentUserId, Department_Id = @DepartmentId WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", districDsParent.Id);
            dbConnection.cmd.Parameters.AddWithValue("@ParentUserId", districDsParent.ParentUserId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentId", districDsParent.DepartmentId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int Delete(DistricDsParent districDsParent, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "DELETE FROM Distric_Ds_Parent WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", districDsParent.Id);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<DistricDsParent> GetAllDistricDsParent(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Distric_Ds_Parent";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DistricDsParent>(dbConnection.dr);
        }

        public DistricDsParent GetDistricDsParent(DistricDsParent districDsParent, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Distric_Ds_Parent WHERE Parent_User_Id = @ParentUserId AND Department_Id = @DepartmentId";

            dbConnection.cmd.Parameters.AddWithValue("@ParentUserId", districDsParent.ParentUserId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentId", districDsParent.DepartmentId);

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DistricDsParent>(dbConnection.dr);
        }

        public DistricDsParent GetDistricDsParentFromDep(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Distric_Ds_Parent WHERE Department_Id =" + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DistricDsParent>(dbConnection.dr);
        }

        public DistricDsParent GetDistricDsParentFromId(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Distric_Ds_Parent WHERE id =" + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DistricDsParent>(dbConnection.dr);
        }
    }
}
