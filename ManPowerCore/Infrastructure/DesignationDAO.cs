using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DesignationDAO
    {
        int SaveDesignation(Designation designation, DBConnection dbConnection);
        int UpdateDesignation(Designation designation, DBConnection dbConnection);
        List<Designation> GetAllDesignation(DBConnection dbConnection);
        Designation GetDesignation(int id, DBConnection dbConnection);
    }

    public class DesignationDAOImpl : DesignationDAO
    {

        public int SaveDesignation(Designation designation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO DESIGNATION(NAME) values (@DesigntionName) ";


            dbConnection.cmd.Parameters.AddWithValue("@DesigntionName", designation.DesigntionName);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateDesignation(Designation designation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE DESIGNATION SET NAME = @DesigntionName, IS_ACTIVE = @IsActive  WHERE ID = @DesignationId ";


            dbConnection.cmd.Parameters.AddWithValue("@DesignationId", designation.DesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@DesigntionName", designation.DesigntionName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", designation.IsActive);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Designation> GetAllDesignation(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DESIGNATION ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Designation>(dbConnection.dr);

        }

        public Designation GetDesignation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DESIGNATION WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Designation>(dbConnection.dr);

        }
    }
}
