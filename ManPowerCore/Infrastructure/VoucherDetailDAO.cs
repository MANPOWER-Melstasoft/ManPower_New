using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VoucherDetailDAO
    {
        int Save(VoucherDetail voucherDetail, DBConnection dbConnection);

        int Update(VoucherDetail voucherDetail, DBConnection dbConnection);

        List<VoucherDetail> GetAllVoucherDetail(DBConnection dbConnection);
    }

    public class VoucherDetailDAOSqlImpl : VoucherDetailDAO
    {
        public int Save(VoucherDetail voucherDetail, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Voucher_Details (Payment_Voucher_Id, Account_Code_Id, Amount) " +
            "VALUES (@PaymentVoucherId, @AccountCodeId, @Amount)";

            dbConnection.cmd.Parameters.AddWithValue("@PaymentVoucherId", voucherDetail.PaymentVoucherId);
            dbConnection.cmd.Parameters.AddWithValue("@AccountCodeId", voucherDetail.AccountCodeId);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", voucherDetail.Amount);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(VoucherDetail voucherDetail, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Voucher_Details SET Payment_Voucher_Id = @PaymentVoucherId, Account_Code_Id = @AccountCodeId, Amount = @Amount " +
            "WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", voucherDetail.PaymentVoucherId);
            dbConnection.cmd.Parameters.AddWithValue("@PaymentVoucherId", voucherDetail.PaymentVoucherId);
            dbConnection.cmd.Parameters.AddWithValue("@AccountCodeId", voucherDetail.AccountCodeId);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", voucherDetail.Amount);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<VoucherDetail> GetAllVoucherDetail(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Voucher_Details";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoucherDetail>(dbConnection.dr);
        }
    }
}
