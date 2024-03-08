using System.Data.SqlClient;
using System;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDao
    {
        public Transfer CreateNewTransfer(int toAccount)
        {
            User newUser = null;

            string sql = "INSERT INTO transfer (transfer_type_id, transfer_status,_id, account_from, account_to, amount ) " +
                         "OUTPUT INSERTED.transfer_id " +
                         "VALUES (@transfer_type_id, @transfer_status_id, @account_from @account_to, @amount)";

            int newUserId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // create user
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);

                    newUserId = Convert.ToInt32(cmd.ExecuteScalar());

                    // create account
                    cmd = new SqlCommand("INSERT INTO account (user_id, balance) VALUES (@userid, @startBalance)", conn);
                    cmd.Parameters.AddWithValue("@userid", newUserId);
                    cmd.Parameters.AddWithValue("@startBalance", StartingBalance);
                    cmd.ExecuteNonQuery();
                }
                newUser = GetUserById(newUserId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newUser;
        }
    }
}
