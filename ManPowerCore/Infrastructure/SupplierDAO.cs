using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface SupplierDAO
    {
        int Save(Supplier supplier, DBConnection dbConnection);

        int Update(Supplier supplier, DBConnection dbConnection);

        List<Supplier> GetAllSupplier(DBConnection dbConnection);
    }

    public class SupplierDAOSqlImpl : SupplierDAO
    {
        public int Save(Supplier supplier, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Supplier (Supplier_Type_Id, Name, Address, Vat_Reg_Number, Created_Date, Created_User, Status_Id) " +
                "VALUES (@SupplierTypeId, @Name, @Address, @VatRegNumber, @CreatedDate, @CreatedUser, @StatusId)";

            dbConnection.cmd.Parameters.AddWithValue("@SupplierTypeId", supplier.SupplierTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", supplier.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Address", supplier.Address);
            dbConnection.cmd.Parameters.AddWithValue("@VatRegNumber", supplier.VatRegNumber);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", supplier.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", supplier.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", supplier.StatusId);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(Supplier supplier, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Supplier SET Supplier_Type_Id = @SupplierTypeId, Name = @Name, Address = @Address, Vat_Reg_Number = @VatRegNumber, " +
                "Created_Date = @CreatedDate, Created_User = @CreatedUser, Status_Id = @StatusId WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@SupplierTypeId", supplier.SupplierTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", supplier.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Address", supplier.Address);
            dbConnection.cmd.Parameters.AddWithValue("@VatRegNumber", supplier.VatRegNumber);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", supplier.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", supplier.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", supplier.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@Id", supplier.Id);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<Supplier> GetAllSupplier(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Supplier";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Supplier>(dbConnection.dr);
        }
    }
}
