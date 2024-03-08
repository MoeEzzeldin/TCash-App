using System.Collections.Generic;
using TenmoServer.Models;


namespace TenmoServer.DAO
{
    public interface IBalanceDao
    {
        //decimal GetBalanceByAccountId(int accountId);
        decimal GetBalanceByUserId(int userId);

        public decimal UpdateFromBalance(decimal amountToDesposit,int fromUserId);

        public decimal UpdateToBalance(decimal amountToDesposit, int toUserId);
    }

}

