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
<<<<<<< HEAD
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

=======
        //public bool CheckForValidUserId(int userInput, List<User> list)
        //{
        //    bool result = false;
        //    foreach (User user in list)
        //    {
        //        if (user.UserId == userInput)
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}
        //public bool DoIHaveEnoughBalanceToTransfer(decimal fromBalance, decimal amountToTransfer)
        //{
        //    bool result = false;
        //    if (fromBalance - amountToTransfer >= 0)
        //    {
               
        //        result = true;
        //    }
        //    return result;
        //}
        //public void TransferFunds(decimal fromBalance, decimal toBalance, decimal amountToTransfer)
        //{
        //    fromBalance = fromBalance - amountToTransfer;
        //    toBalance = toBalance + amountToTransfer;
        //}
>>>>>>> db10b0f8eb680cbe271b01c6a6df800c7a74a3ec
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
