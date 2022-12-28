using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VoteLedgerDAO
    {
        int Save(VoteLedger voteLedger, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int ApproveVoteLedger(VoteLedger voteLedger, DBConnection dbConnection);
        List<VoteLedger> GetAllVoteLedger(bool with0, DBConnection dbConnection);
        VoteLedger GetVoteLedger(int id, DBConnection dbConnection);
    }

    public class VoteLedgerDAOSqlImpl : VoteLedgerDAO
    {
        public int Save(VoteLedger voteLedger, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Vote_Ledger (From_Vote, To_Vote, Amount, Created_By, Created_Date) " +
                "VALUES (@FromVote, @ToVote, @Amount, @CreatedBy, @CreatedDate) ";

            dbConnection.cmd.Parameters.AddWithValue("@FromVote", voteLedger.FromVote);
            dbConnection.cmd.Parameters.AddWithValue("@ToVote", voteLedger.ToVote);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", voteLedger.Amount);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedBy", voteLedger.CreatedBy);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", voteLedger.CreatedDate);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Vote_Ledger SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int ApproveVoteLedger(VoteLedger voteLedger, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Vote_Ledger SET Approved_By = @ApprovedBy, Approved_Date = @ApprovedDate WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", voteLedger.Id);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", voteLedger.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", voteLedger.ApprovedDate);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<VoteLedger> GetAllVoteLedger(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Ledger";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Ledger WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoteLedger>(dbConnection.dr);
        }

        public VoteLedger GetVoteLedger(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Vote_Ledger WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<VoteLedger>(dbConnection.dr);
        }
    }
}
