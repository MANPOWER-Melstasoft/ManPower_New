using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface VoteAllocationController
    {
        List<VoteAllocation> getallVoteAllocation();
    }
    public class VoteAllocationControllerImpl : VoteAllocationController
    {
        DBConnection dBConnection = null;
        public List<VoteAllocation> getallVoteAllocation()
        {

            try
            {
                dBConnection = new DBConnection();
                List<VoteAllocation> voteList = new List<VoteAllocation>();
                VoteAllocationDAO dao = DAOFactory.CreateVoteAllocationDAO();

                voteList = dao.getallVoteAllocation(dBConnection);
                return voteList;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }


        }
    }

}
