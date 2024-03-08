using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TenmoClient.Methods;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoConsoleService : ConsoleService
    {
        TransferMethods transferMethods = new TransferMethods();
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
        //public void SendTEBucks(List<User> differentUsers, decimal currentBalance)
        //{
        //    bool done = false;
        //    while (!done)
        //    {
        //        try
        //        {
        //            Console.WriteLine(); //good
        //            string header = $"{"User Id".PadLeft(10)}{"Username".PadLeft(10)}\n";
        //            Console.WriteLine(header);
        //            foreach (User user in differentUsers)
        //            {
        //                Console.WriteLine(user);
        //            }
        //            Pause();
        //            Console.WriteLine();
        //            Console.Write("Select the User ID of the individual you would like to send money to: ");
        //            string userIdSelectionString = Console.ReadLine();
        //            int userIdSelection = int.Parse(userIdSelectionString);
        //            bool test = transferMethods.CheckForValidUserId(userIdSelection, differentUsers);
        //            Console.WriteLine();
        //            if (test)
        //            {
        //                Console.Write("Enter the amount of TEBucks you would like to send: ");
        //                int transferAmount = int.Parse(Console.ReadLine());

        //                //if (transferMethods.DoIHaveEnoughBalanceToTransfer(currentBalance, transferAmount))
        //                //{

        //                //    Console.WriteLine($"Success! You just sent " + transferAmount + " TE Bucks!");
        //                //    Console.WriteLine();
        //                //    Pause();
        //                //    break;
        //                //}
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid User ID. Please try again");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            PrintError(ex.Message);
        //        }
        //        Pause();
        //        Console.WriteLine();
        //    }
        //}

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
                    //Pause();
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
            Console.WriteLine("testing");
            //Console.WriteLine($"You've successfully send {amountSent.ToString("C")} TE Bucks." );
        }
        // Add application-specific UI methods here...
    }
}
