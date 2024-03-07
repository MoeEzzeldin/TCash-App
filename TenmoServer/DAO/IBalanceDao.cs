using System.Collections.Generic;
using TenmoServer.Models;


namespace TenmoServer.DAO
{
    public interface IBalanceDao
    {
        //decimal GetBalanceByAccountId(int accountId);
        decimal GetBalanceByUserId(int userId);
    }
}

