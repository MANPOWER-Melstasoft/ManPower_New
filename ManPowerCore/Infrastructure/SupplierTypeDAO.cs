using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface SupplierTypeDAO
    {
        int Save(SupplierType supplierType, DBConnection dbConnection);

        int Update(SupplierType supplierType, DBConnection dbConnection);

        List<SupplierType> GetAllSupplierType(DBConnection dbConnection);
    }

    public class SupplierTypeDAOSqlImpl : SupplierTypeDAO
    {
        public int Save(SupplierType supplierType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Supplier_Type (Supply_Type_Name, Is_Active) " +
                "VALUES (@SupplyTypeName, @IsActive)";

            dbConnection.cmd.Parameters.AddWithValue("@SupplyTypeName", supplierType.SupplyTypeName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", supplierType.IsActive);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(SupplierType supplierType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Supplier_Type " +
                "SET Supply_Type_Name = @SupplyTypeName, Is_Active = @IsActive " +
                "WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@SupplyTypeName", supplierType.SupplyTypeName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", supplierType.IsActive);
            dbConnection.cmd.Parameters.AddWithValue("@Id", supplierType.Id);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<SupplierType> GetAllSupplierType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Supplier_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SupplierType>(dbConnection.dr);
        }
    }
}
