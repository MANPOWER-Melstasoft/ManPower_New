using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface GuarantorDetailDAO
    {
        int Save(GuarantorDetail guarantorDetail, DBConnection dbConnection);

        int Update(GuarantorDetail guarantorDetail, DBConnection dbConnection);

        List<GuarantorDetail> GetAllGuarantorDetail(DBConnection dbConnection);
    }

    public class GuarantorDetailDAOSqlImpl : GuarantorDetailDAO
    {
        public int Save(GuarantorDetail guarantorDetail, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Guarantor_Detail (Distress_Loan_Id, Name, Position, Appointed_Date, Address) " +
                                "VALUES (@DistressLoanId, @Name, @Position, @AppointedDate, @Address)";

            dbConnection.cmd.Parameters.AddWithValue("@DistressLoanId", guarantorDetail.DistressLoanId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", guarantorDetail.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Position", guarantorDetail.Position);
            dbConnection.cmd.Parameters.AddWithValue("@AppointedDate", guarantorDetail.AppointedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Address", guarantorDetail.Address);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(GuarantorDetail guarantorDetail, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Guarantor_Detail SET Distress_Loan_Id = @DistressLoanId, Name = @Name, Position = @Position, Appointed_Date = @AppointedDate, Address = @Address " +
                                "WHERE Id = @GuarantorDetailId";

            dbConnection.cmd.Parameters.AddWithValue("@DistressLoanId", guarantorDetail.DistressLoanId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", guarantorDetail.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Position", guarantorDetail.Position);
            dbConnection.cmd.Parameters.AddWithValue("@AppointedDate", guarantorDetail.AppointedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Address", guarantorDetail.Address);
            dbConnection.cmd.Parameters.AddWithValue("@GuarantorDetailId", guarantorDetail.GuarantorDetailId);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<GuarantorDetail> GetAllGuarantorDetail(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Guarantor_Detail";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<GuarantorDetail>(dbConnection.dr);
        }
    }
}
