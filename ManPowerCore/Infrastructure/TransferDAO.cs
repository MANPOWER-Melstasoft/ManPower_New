using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TransferDAO
    {
        int Save(Transfer transfer, DBConnection dbConnection);
        int Delete(int id, DBConnection dbConnection);
        int Update(Transfer transfer, DBConnection dbConnection);
        List<Transfer> GetAllTransfer(bool with0, DBConnection dbConnection);
        Transfer GetTransferByMainId(int Id, DBConnection dbConnection);
    }

    public class TransferDAOSqlImpl : TransferDAO
    {
        public int Save(Transfer transfer, DBConnection dbConnection)
        {
            int output = 0;
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();

            if (transfer.NextDep != 0)
            {

                dbConnection.cmd.CommandText = "INSERT INTO Transfer (Transfers_Retirement_Resignation_Main_Id, Transfer_Type, Current_Dep, Department_Unit_Id, Reason, From_Date, To_Date,Prefered_Work_Place2,Prefered_Work_Place3)" +
                    "VALUES (@MainId, @TransferType, @CurrentDep, @NextDep, @Reason, @FromDate, @ToDate,@PreferedWorkPlace2,@PreferdWorkPlace3)";
            }
            else
            {
                dbConnection.cmd.CommandText = "INSERT INTO Transfer (Transfers_Retirement_Resignation_Main_Id, Transfer_Type, Current_Dep, Reason, From_Date, To_Date, Request_Work_Place)" +
               "VALUES (@MainId, @TransferType, @CurrentDep, @Reason, @FromDate, @ToDate, @RequestWorkPlace)";

            }

            dbConnection.cmd.Parameters.AddWithValue("@MainId", transfer.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@TransferType", transfer.TransferType);
            dbConnection.cmd.Parameters.AddWithValue("@CurrentDep", transfer.CurrentDep);
            dbConnection.cmd.Parameters.AddWithValue("@NextDep", transfer.NextDep);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", transfer.Reason);

            dbConnection.cmd.Parameters.AddWithValue("@PreferedWorkPlace2", transfer.PreferedWorkPlace2);
            dbConnection.cmd.Parameters.AddWithValue("@PreferdWorkPlace3", transfer.PreferdWorkPlace3);


            if (transfer.FromDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@FromDate", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@FromDate", transfer.FromDate);
            }

            if (transfer.ToDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@ToDate", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@ToDate", transfer.ToDate);
            }
            dbConnection.cmd.Parameters.AddWithValue("@RequestWorkPlace", transfer.RequestWorkPlace);

            output = dbConnection.cmd.ExecuteNonQuery();
            return output;
        }

        public int Update(Transfer transfer, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfer SET Transfers_Retirement_Resignation_Main_Id = @MainId, Transfer_Type = @TransferType," +
                "Current_Dep = @CurrentDep, Department_Unit_Id = @NextDep, Reason = @Reason, From_Date = @FromDate, To_Date = @ToDate WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", transfer.Id);
            dbConnection.cmd.Parameters.AddWithValue("@MainId", transfer.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@TransferType", transfer.TransferType);
            dbConnection.cmd.Parameters.AddWithValue("@CurrentDep", transfer.CurrentDep);
            dbConnection.cmd.Parameters.AddWithValue("@NextDep", transfer.NextDep);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", transfer.Reason);

            if (transfer.FromDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@FromDate", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@FromDate", transfer.FromDate);
            }

            if (transfer.ToDate.Year == 1)
            {
                dbConnection.cmd.Parameters.AddWithValue("@ToDate", SqlDateTime.Null);
            }
            else
            {
                dbConnection.cmd.Parameters.AddWithValue("@ToDate", transfer.ToDate);
            }

            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public int Delete(int id, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfer SET Is_Active = 0 WHERE ID = @Id ";

            dbConnection.cmd.Parameters.AddWithValue("@Id", id);


            output = dbConnection.cmd.ExecuteNonQuery();

            return output;
        }

        public List<Transfer> GetAllTransfer(bool with0, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            if (with0)
                dbConnection.cmd.CommandText = "SELECT * FROM Transfer";
            else
                dbConnection.cmd.CommandText = "SELECT * FROM Transfer WHERE Is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Transfer>(dbConnection.dr);
        }

        public Transfer GetTransferByMainId(int Id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Transfer WHERE Transfers_Retirement_Resignation_Main_Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Transfer>(dbConnection.dr);
        }

    }
}
