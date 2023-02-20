using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface RequestorGuarantorDAO
    {
        int Save(RequestorGuarantor requestorGuarantor, DBConnection dbConnection);

        int Update(RequestorGuarantor requestorGuarantor, DBConnection dbConnection);

        List<RequestorGuarantor> GetAllRequestorGuarantor(DBConnection dbConnection);
    }

    public class RequestorGuarantorDAOSqlImpl : RequestorGuarantorDAO
    {
        public int Save(RequestorGuarantor requestorGuarantor, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Requestor_Guarantor (Distress_Loan_Id, Name_Of_Officer, Amount, Periodical_Amount, Interest) " +
                                "VALUES (@DistressLoanId, @OfficerName, @Amount, @PeriodicalAmount, @Interest, @Position)";

            dbConnection.cmd.Parameters.AddWithValue("@DistressLoanId", requestorGuarantor.DistressLoanId);
            dbConnection.cmd.Parameters.AddWithValue("@OfficerName", requestorGuarantor.OfficerName);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", requestorGuarantor.Amount);
            dbConnection.cmd.Parameters.AddWithValue("@PeriodicalAmount", requestorGuarantor.PeriodicalAmount);
            dbConnection.cmd.Parameters.AddWithValue("@Interest", requestorGuarantor.Interest);
            dbConnection.cmd.Parameters.AddWithValue("@Position", requestorGuarantor.Position);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(RequestorGuarantor requestorGuarantor, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Requestor_Guarantor SET Name_Of_Officer = @OfficerName, Amount = @Amount, Periodical_Amount = @PeriodicalAmount, Interest = @Interest, Position = @Position " +
                                "WHERE Id = @GuarantorDetailId";

            dbConnection.cmd.Parameters.AddWithValue("@OfficerName", requestorGuarantor.OfficerName);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", requestorGuarantor.Amount);
            dbConnection.cmd.Parameters.AddWithValue("@PeriodicalAmount", requestorGuarantor.PeriodicalAmount);
            dbConnection.cmd.Parameters.AddWithValue("@Interest", requestorGuarantor.Interest);
            dbConnection.cmd.Parameters.AddWithValue("@GuarantorDetailId", requestorGuarantor.GuarantorDetailId);
            dbConnection.cmd.Parameters.AddWithValue("@Position", requestorGuarantor.Position);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public List<RequestorGuarantor> GetAllRequestorGuarantor(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Requestor_Guarantor";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<RequestorGuarantor>(dbConnection.dr);
        }
    }
}
