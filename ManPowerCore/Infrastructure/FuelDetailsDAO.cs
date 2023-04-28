using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface FuelDetailsDAO
    {
        int SaveAll(FuelDetailsDomain fuelDetailsDomain, DBConnection dbConnection);
        List<FuelDetailsDomain> GetAll(DBConnection dbConnection);
    }
    public class FuelDetailsDAOSqlImpl : FuelDetailsDAO
    {
        public int SaveAll(FuelDetailsDomain fuelDetailsDomain, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO FUEL_Details(Vehicle_Number,Fuel_Type_Id,Liters,CreatedDate,OrderNumber,Employee_Name,Employee_ID) " +
                "VALUES(@VehicleNumber,@FuelTypeId,@LitersCount,@CreatedDate,@OrderNumber,@EmployeeName,@EmployeeId)";

            dbConnection.cmd.Parameters.AddWithValue("@VehicleNumber", fuelDetailsDomain.VehicleNumber);
            dbConnection.cmd.Parameters.AddWithValue("@LitersCount", fuelDetailsDomain.LitersCount);
            dbConnection.cmd.Parameters.AddWithValue("@FuelTypeId", fuelDetailsDomain.FuelTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", fuelDetailsDomain.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@OrderNumber", fuelDetailsDomain.OrderNumber);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeName", fuelDetailsDomain.EmployeeName);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", fuelDetailsDomain.EmployeeId);

            return dbConnection.cmd.ExecuteNonQuery();


        }

        public List<FuelDetailsDomain> GetAll(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "SELECT * FROM FUEL_Details";


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<FuelDetailsDomain>(dbConnection.dr);

        }
    }
}

