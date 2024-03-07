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
    }
}
