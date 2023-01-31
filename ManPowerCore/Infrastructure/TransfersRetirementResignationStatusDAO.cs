using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TransfersRetirementResignationStatusDAO
    {
        List<TransfersRetirementResignationStatus> GetAllStatus(bool with0, DBConnection dbConnection);
        TransfersRetirementResignationStatus GetStatus(int id, DBConnection dbConnection);
    }

    public class TransfersRetirementResignationStatusDAOSqlImpl : TransfersRetirementResignationStatusDAO
    {
        public List<TransfersRetirementResignationStatus> GetAllStatus(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Status";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Status WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TransfersRetirementResignationStatus>(dbConnection.dr);
        }

        public TransfersRetirementResignationStatus GetStatus(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Transfers_Retirement_Resignation_Status WHERE Id = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TransfersRetirementResignationStatus>(dbConnection.dr);
        }
    }
}
