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
    public interface VoteAllocationDAO
    {
        List<VoteAllocation> getallVoteAllocation(DBConnection dbConnection);
    }
    public class VoteAllocationDAOSqlImpl : VoteAllocationDAO
    {
        public List<VoteAllocation> getallVoteAllocation(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Vote_Allocation";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoteAllocation>(dbConnection.dr);

        }
    }
}
