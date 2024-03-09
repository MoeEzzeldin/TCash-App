using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TenmoClient.Models;
using TenmoServer.Exceptions;

namespace TenmoClient.Services
{
    public class TenmoConsoleService : ConsoleService
    {
        Transfer transfer = new Transfer();
        User user = new User();
        Account account = new Account();
        /************************************************************
            Print methods
        ************************************************************/
        public void PrintLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to TEnmo!");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        public void PrintMainMenu(string username)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {username}!");
            Console.WriteLine("1: View your current balance");
            Console.WriteLine("2: View your past transfers");
            Console.WriteLine("3: View your pending requests");
            Console.WriteLine("4: Send TE bucks");
            Console.WriteLine("5: Request TE bucks");
            Console.WriteLine("6: Log out");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }
        public LoginUser PromptForLogin()
        {
            string username = PromptForString("User name");
            if (String.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            string password = PromptForHiddenString("Password");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        public void PrintBalance(decimal balance)
        {
            Console.WriteLine("\nYour Current Balance is: " + balance);
        }
        public int GetsUserIdToSendMoneyTo(List<User> differentUsers)
        {
            int userIdSelection = 0;
            bool done = false;
            while (!done)
            {
                try
                {
                    string header = $"{"User Id".PadLeft(10)}{"Username".PadLeft(10)}\n";
                    Console.WriteLine(header);
                    foreach (User user in differentUsers)
                    {
                        Console.WriteLine(user);
                    }
                    Console.WriteLine();
                    Console.Write("Select the User ID of the individual you would like to send money to: ");
                    string userIdSelectionString = Console.ReadLine();
                    userIdSelection = int.Parse(userIdSelectionString);
                    Pause();
                    Console.WriteLine();
                    break;
                }
                catch (Exception ex)
                {
                    PrintError(ex.Message);
                }
            }
            return userIdSelection;
        }
        public decimal PromptingUserForAmountToSend()
        {
            Transfer transfer = new Transfer();
            //int userInput = 0;
            bool done = false;
            while (!done)
            {
                try
                {
                    Console.Write("Enter the amount of TE Bucks you would like to send: ");
                    //userInput = int.Parse(Console.ReadLine());
                    transfer.Amount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch (Exception ex)
                {
                    PrintError(ex.Message);
                }
            }
            return transfer.Amount;
        }
        public void Success(decimal amountSent)
        {
            Console.WriteLine();
            Console.WriteLine($"You've successfully send {amountSent.ToString("C")} TE Bucks." );
            Pause();
        }
        public void PrintTransactionDetails(List<TransferHistoryDTO> listOfTransactions)
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    Console.WriteLine("Select a user for more details.");
                    string header = $"  {"User Id".PadRight(10)}{"From".PadRight(12)}{"To".PadRight(8)}{"Amount".PadRight(8)}\n";
                    Console.WriteLine(header);
                    int counter = 1;
                    foreach (TransferHistoryDTO temp in listOfTransactions)
                    {
                        //Console.WriteLine(temp);
                        Console.WriteLine($"{counter}: {temp}");
                        counter++;
                    }

                    break;
                }
                catch (Exception ex)
                {
                    PrintError(ex.Message);
                }
                Console.WriteLine();
            }
        }
        // Add application-specific UI methods here...
    }
}
