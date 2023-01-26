using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface RetirementTypeDAO
    {
        List<RetirementType> GetAllRetirementType(bool with0, DBConnection dbConnection);
    }
    public class RetirementTypeDAOSqlImpl : RetirementTypeDAO
    {
        public List<RetirementType> GetAllRetirementType(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Retirement_Type";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Retirement_Type WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<RetirementType>(dbConnection.dr);
        }
    }
}
