using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface RetirementDAO
    {
        int Save(Retirement resignation, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int Update(Retirement resignation, DBConnection dbConnection);
        List<Retirement> GetAllRetirement(bool with0, DBConnection dbConnection);
        Retirement GetRetirementByMainId(int Id, DBConnection dbConnection);
    }

    public class RetirementDAOSqlImpl : RetirementDAO
    {
        public int Save(Retirement resignation, DBConnection dbConnection)
        {
            int output = 0;
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO Retirement (Transfers_Retirement_Resignation_Main_Id, Joined_Date, Reason, Retirement_Type, Remark)" +
                "VALUES (@MainId, @JoinedDate, @Reason, @RetirementType, @Remark)";

            dbConnection.cmd.Parameters.AddWithValue("@MainId", resignation.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@JoinedDate", resignation.JoinedDate);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", resignation.Reason);
            dbConnection.cmd.Parameters.AddWithValue("@RetirementType", resignation.RetirementType);
            dbConnection.cmd.Parameters.AddWithValue("@Remark", resignation.Remark);

            output = dbConnection.cmd.ExecuteNonQuery();
            return output;
        }

        public int Update(Retirement resignation, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Retirement SET Transfers_Retirement_Resignation_Main_Id = @MainId, Retirement_Type = @RetirementType," +
                "Joined_Date = @JoinedDate, Reason = @Reason, Remark = @Remark WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", resignation.Id);
            dbConnection.cmd.Parameters.AddWithValue("@MainId", resignation.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@JoinedDate", resignation.JoinedDate);
            dbConnection.cmd.Parameters.AddWithValue("@RetirementType", resignation.RetirementType);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", resignation.Reason);
            dbConnection.cmd.Parameters.AddWithValue("@Remark", resignation.Remark);

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Retirement SET Is_Active = 0 WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", id);


            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public List<Retirement> GetAllRetirement(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Retirement";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Retirement WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Retirement>(dbConnection.dr);
        }

        public Retirement GetRetirementByMainId(int Id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Retirement WHERE Transfers_Retirement_Resignation_Main_Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Retirement>(dbConnection.dr);
        }

    }
}
