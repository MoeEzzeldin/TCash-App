using System.Data.SqlClient;
using System;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security.Models;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Collections.Generic;
using TenmoServer.DAO.Interfaces;

namespace TenmoServer.DAO
{
    public class TransferSqlDao : ITransferDao
    {
        private readonly string connectionString;

        public TransferSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Transfer CreateNewTransfer(int accountTo, int accountFrom, decimal amount)
        {
            int newTransferId;
            string sql = "INSERT INTO transfer (transfer_type_id, transfer_status_id, account_from, account_to, amount ) " +
                         "OUTPUT INSERTED.transfer_id " +
                         "VALUES (2, 2, (SELECT account_id FROM account WHERE user_id = @from_user_id), (SELECT account_id FROM account WHERE user_id = @to_user_id), @amount);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@to_user_id", accountTo);
                    cmd.Parameters.AddWithValue("@from_user_id", accountFrom);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    newTransferId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return GetTransferById(newTransferId);
        }
        public Transfer GetTransferById(int transferId)
        {
            Transfer newTransfer = null;
            string sql = @"SELECT transfer_id, transfer_type_id, transfer_status_id, account_from, account_to, amount FROM transfer
                WHERE transfer_id = @transfer_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@transfer_id", transferId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        newTransfer = MapRowToTransfer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newTransfer;
        }
        //public List<TransferHistoryDTO> UserTransferHistory(int userId)
        //{
        //    TransferHistoryDTO myObj = new TransferHistoryDTO();
        //    List<TransferHistoryDTO> transferHistory = new List<TransferHistoryDTO>();
        //    string sql = @"SELECT transfer_id, account_from, account_to, amount FROM transfer";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            //cmd.Parameters.AddWithValue("@user_id", userId);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                myObj = TransferHistoryMapping(reader);
        //                transferHistory.Add(myObj);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new DaoException("SQL exception occurred", ex);
        //    }
        //    return transferHistory;
        //}
        public List<TransferHistoryDTO> UserTransferHistory(string me)
        {
            TransferHistoryDTO myObj = new TransferHistoryDTO();
            List<TransferHistoryDTO> transferHistory = new List<TransferHistoryDTO>();
            string sql = @"SELECT t.transfer_id, u_from.username AS from_username, u_to.username AS to_username, t.amount FROM transfer t
            JOIN account a_from ON t.account_from = a_from.account_id
            JOIN account a_to ON t.account_to = a_to.account_id
            JOIN tenmo_user u_from ON a_from.user_id = u_from.user_id
            JOIN tenmo_user u_to ON a_to.user_id = u_to.user_id
            WHERE u_from.username = @me OR u_to.username = @me;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@me", me);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        myObj = TransferHistoryMapping(reader);
                        transferHistory.Add(myObj);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return transferHistory;
        }

        private TransferHistoryDTO TransferHistoryMapping(SqlDataReader reader)
        {
            TransferHistoryDTO transfer = new TransferHistoryDTO();
            transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
            transfer.AccountFromUsername = Convert.ToString(reader["from_username"]);
            transfer.AccountToUsername = Convert.ToString(reader["to_username"]);
            transfer.Amount = Convert.ToDecimal(reader["amount"]);

            return transfer;
        }
        private Transfer MapRowToTransfer(SqlDataReader reader)
        {
            Transfer transfer = new Transfer();
            transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
            transfer.TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]);
            transfer.TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]);
            transfer.AccountFrom = Convert.ToInt32(reader["account_from"]);
            transfer.AccountTo = Convert.ToInt32(reader["account_to"]);
            transfer.Amount = Convert.ToDecimal(reader["amount"]);

            return transfer;
        }
    }
}
