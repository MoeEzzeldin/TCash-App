using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Principal;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security;
using TenmoServer.Security.Models;
namespace TenmoServer.DAO
{
    public class BalanceSqlDao : IBalanceDao
    {
        private readonly string connectionString;
        //const decimal StartingBalance = 1000M;
        public BalanceSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public decimal GetBalanceByUserId(int userId)
        {
            Account account = new Account();
            string sql = "SELECT balance FROM account WHERE user_id = @user_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        account.Balance = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return account.Balance;
        }
<<<<<<< HEAD
=======

>>>>>>> 2a0a391cde59029b6bbdb6a9b3f4667df6c3b566
        public decimal UpdateFromBalance(decimal amountToDesposit, int fromUserId)
        {
            Account account = new Account();
            string sql = "UPDATE account SET balance = balance-@balance WHERE user_id = @user_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@balance", amountToDesposit);
                    cmd.Parameters.AddWithValue("@user_id", fromUserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        account.Balance = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return account.Balance;
        }
        public decimal UpdateToBalance(decimal amountToDesposit, int toUserId)
        {
            Account account = new Account();
            string sql = "UPDATE account SET balance = balance + @balance WHERE user_id = @user_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@balance", amountToDesposit);
                    cmd.Parameters.AddWithValue("@user_id", toUserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        account.Balance = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return account.Balance;
        }
        private decimal MapRowToUser(SqlDataReader reader)
        {
            Account account = new Account();
            account.Balance = Convert.ToInt32(reader["balance"]);
            return account.Balance;
        }
    }
}