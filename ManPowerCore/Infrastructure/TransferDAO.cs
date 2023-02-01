﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
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
        Transfer GetTransfer(int Id, DBConnection dbConnection);
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
            dbConnection.cmd.CommandText = "INSERT INTO Transfer (Transfers_Retirement_Resignation_Main_Id, Transfer_Type, Current_Dep, Department_Unit_Id, Reason)" +
                "VALUES (@MainId, @TransferType, @CurrentDep, @NextDep, @Reason)";

            dbConnection.cmd.Parameters.AddWithValue("@MainId", transfer.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@TransferType", transfer.TransferType);
            dbConnection.cmd.Parameters.AddWithValue("@CurrentDep", transfer.CurrentDep);
            dbConnection.cmd.Parameters.AddWithValue("@NextDep", transfer.NextDep);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", transfer.Reason);

            output = dbConnection.cmd.ExecuteNonQuery();
            return output;
        }

        public int Update(Transfer transfer, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Transfer SET Transfers_Retirement_Resignation_Main_Id = @MainId, Transfer_Type = @TransferType," +
                "Current_Dep = @CurrentDep, Department_Unit_Id = @NextDep, Reason = @Reason WHERE ID = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", transfer.Id);
            dbConnection.cmd.Parameters.AddWithValue("@MainId", transfer.MainId);
            dbConnection.cmd.Parameters.AddWithValue("@TransferType", transfer.TransferType);
            dbConnection.cmd.Parameters.AddWithValue("@CurrentDep", transfer.CurrentDep);
            dbConnection.cmd.Parameters.AddWithValue("@NextDep", transfer.NextDep);
            dbConnection.cmd.Parameters.AddWithValue("@Reason", transfer.Reason);

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

        public Transfer GetTransfer(int Id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM Transfer WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", Id);


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Transfer>(dbConnection.dr);
        }

    }
}