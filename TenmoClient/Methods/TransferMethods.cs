using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoClient.Models;
using TenmoServer.DAO;

namespace TenmoClient.Methods
{
    public class TransferMethods
    {
        public bool CheckForValidUserId(int userInput, List<User> list)
        {
            bool result = false;
            foreach (User user in list)
            {
                if (user.UserId == userInput)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public bool DoIHaveEnoughBalanceToTransfer(decimal fromBalance, decimal amountToTransfer)
        {
            bool result = false;
            if (fromBalance - amountToTransfer >= 0)
            {

                result = true;
            }
            return result;
        }

        //public decimal TransferFundsFromAccount(decimal fromBalance, decimal amountToTransfer)
        //{
        //    fromBalance = fromBalance - amountToTransfer;
        //    return fromBalance;
        //}
        //public decimal TransferFundsToAccount(decimal amountToTransfer, decimal toBalance)
        //{
        //    toBalance = toBalance + amountToTransfer;
        //    return toBalance;
        //}
    }
}
