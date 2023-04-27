using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface StaffLeaveDocumentsDAO
    {
        int Save(StaffLeaveDocuments staffLeaveDocuments, DBConnection dbConnection);

        List<StaffLeaveDocuments> GetAllDocuments(DBConnection dbConnection);

    }

    public class StaffLeaveDocumentsDAOSqlImpl : StaffLeaveDocumentsDAO
    {
        public int Save(StaffLeaveDocuments staffLeaveDocuments, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Staff_Leave_Documents (Staff_Leave_Id, Document) " +
                "VALUES (@StaffLeaveId, @Document)";

            dbConnection.cmd.Parameters.AddWithValue("@StaffLeaveId", staffLeaveDocuments.StaffLeaveId);
            dbConnection.cmd.Parameters.AddWithValue("@Document", staffLeaveDocuments.Document);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }


        public List<StaffLeaveDocuments> GetAllDocuments(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Staff_Leave_Documents";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<StaffLeaveDocuments>(dbConnection.dr);
        }


    }
}
