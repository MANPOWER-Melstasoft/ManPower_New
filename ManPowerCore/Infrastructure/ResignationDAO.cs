using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ResignationDAO
    {
        int Save(Resignation resignation, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int Update(Resignation resignation, DBConnection dbConnection);
        List<Resignation> GetAllResignation(bool with0, DBConnection dbConnection);
        Resignation GetResignation(int Id, DBConnection dbConnection);
    }

    public class ResignationDAOSqlImpl : ResignationDAO
    {

        public int Save(Resignation resignation, DBConnection dbConnection)
        {
            int output = 0;
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO Resignation (Transfers_Retirement_Resignation_Main_Id, Resignation_Date, Reason)" +
                "VALUES (@MainId, @ResignationDate, @Reason) ";

            dbConnection.cmd.Parameters.AddWithValue("@MainId", resignation.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@ResignationDate", resignation.ResignationDate);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", resignation.Reason);

            output = dbConnection.cmd.ExecuteNonQuery();
            return output;
        }

        public int Update(Resignation resignation, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Resignation SET Transfers_Retirement_Resignation_Main_Id = @MainId, " +
                "Resignation_Date = @ResignationDate, Reason = @Reason WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", resignation.Id);
            dbConnection.cmd.Parameters.AddWithValue("@MainId", resignation.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@ResignationDate", resignation.ResignationDate);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", resignation.Reason);

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Resignation SET Is_Active = 0 WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", id);


            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public List<Resignation> GetAllResignation(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Resignation";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Resignation WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Resignation>(dbConnection.dr);
        }

        public Resignation GetResignation(int Id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Resignation WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Resignation>(dbConnection.dr);
        }

    }
}
