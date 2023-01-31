using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface RequestTypeDAO
    {
        List<RequestType> GetAllRequestType(bool with0, DBConnection dbConnection);
        RequestType GetRequestType(int id, DBConnection dbConnection);
    }

    public class RequestTypeDAOSqlImpl : RequestTypeDAO
    {
        public List<RequestType> GetAllRequestType(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Request_Type";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Request_Type WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<RequestType>(dbConnection.dr);
        }

        public RequestType GetRequestType(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Request_Type WHERE Id = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<RequestType>(dbConnection.dr);
        }
    }
}
