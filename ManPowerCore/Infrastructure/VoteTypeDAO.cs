using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VoteTypeDAO
    {
        int Save(VoteType voteType, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        List<VoteType> GetAllVoteType(bool with0, DBConnection dbConnection);
    }

    public class VoteTypeDAOSqlImpl : VoteTypeDAO
    {

        public int Save(VoteType voteType, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Vote_Type (Details) values (@Deatils) ";

            dbConnection.cmd.Parameters.AddWithValue("@Deatils", voteType.Deatils);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Vote_Type SET Is_Active = 0 WHERE ID = " + id;

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<VoteType> GetAllVoteType(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Type";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Vote_Type WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoteType>(dbConnection.dr);
        }

    }
}
