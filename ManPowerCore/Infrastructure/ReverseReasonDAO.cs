using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ReverseReasonDAO
    {
        List<ReverseReason> GetAllReverseReason(bool with0, DBConnection dbConnection);
    }

    public class ReverseReasonDAOSqlImpl : ReverseReasonDAO
    {
        public List<ReverseReason> GetAllReverseReason(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Reverse_Reason";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Reverse_Reason WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ReverseReason>(dbConnection.dr);
        }
    }
}
