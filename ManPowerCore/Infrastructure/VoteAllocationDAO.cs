using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VoteAllocationDAO
    {
        int Save(VoteAllocation voteAllocation, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int ChangeRemain(VoteAllocation voteAllocation, DBConnection dbConnection);
        List<VoteAllocation> GetAllVoteAllocation(bool with0, DBConnection dbConnection);
        VoteAllocation GetVoteAllocation(int id, DBConnection dbConnection);

    }

    public class VoteAllocationDAOSqlImpl : VoteAllocationDAO
    {

        public int Save(VoteAllocation voteAllocation, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Vote_Allocation (Vote_Type_ID, Year_Allocation, Vote_Number, Amount, Reamin_Amount, Created_By, Created_Date) " +
                "VALUES (@VoteTypeId, @Year, @VoteNumber, @Amount, @RemainAmount, @CreatedBy, @CreatedDate) ";

            dbConnection.cmd.Parameters.AddWithValue("@VoteTypeId", voteAllocation.VoteTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@Year", voteAllocation.Year);
            dbConnection.cmd.Parameters.AddWithValue("@VoteNumber", voteAllocation.VoteNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Amount", voteAllocation.Amount);
            dbConnection.cmd.Parameters.AddWithValue("@RemainAmount", voteAllocation.RemainAmount);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedBy", voteAllocation.CreatedBy);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", voteAllocation.CreatedDate);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Vote_Allocation SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int ChangeRemain(VoteAllocation voteAllocation, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Vote_Allocation SET Reamin_Amount = @RemainAmount WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", voteAllocation.Id);
            dbConnection.cmd.Parameters.AddWithValue("@RemainAmount", voteAllocation.RemainAmount);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<VoteAllocation> GetAllVoteAllocation(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Allocation";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Allocation WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoteAllocation>(dbConnection.dr);
        }

        public VoteAllocation GetVoteAllocation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Vote_Allocation WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<VoteAllocation>(dbConnection.dr);
        }
    }
}
