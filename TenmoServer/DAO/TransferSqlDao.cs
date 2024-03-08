using System.Data.SqlClient;
using System;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security.Models;
using System.Security.Cryptography.Xml;
using System.IO;

namespace TenmoServer.DAO
{
    public class TransferSqlDao : ITransferDao
    {
        private readonly string connectionString;

        public TransferSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        //public Transfer CreateNewTransfer(Transfer transfer)
        //{
        //    int newTransferId;
        //    string sql = "INSERT INTO transfer (transfer_type_id, transfer_status_id, account_from, account_to, amount ) " +
        //                 "OUTPUT INSERTED.transfer_id " +
        //                 "VALUES (2, 2, (SELECT account_id FROM account WHERE user_id = @from_user_id), (SELECT account_id FROM account WHERE user_id = @to_user_id), @amount)";

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("@from_user_id", transfer.AccountTo);
        //            cmd.Parameters.AddWithValue("@from_user_id", transfer.AccountFrom);
        //            cmd.Parameters.AddWithValue("@amount", transfer.Amount);

        //            newTransferId = Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new DaoException("SQL exception occurred", ex);
        //    }

        //    return GetTransferById(newTransferId);
        //}
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
