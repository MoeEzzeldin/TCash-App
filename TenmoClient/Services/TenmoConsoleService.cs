using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using TenmoClient.Methods;
using TenmoClient.Models;

namespace TenmoClient.Services
{ 
    public class TenmoConsoleService : ConsoleService
    {
        TransferMethods transferMethods = new TransferMethods();
        Transfer transfer = new Transfer();
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
        public void SendTEBucks(List<User> differentUsers)
        {
            bool done = false;
            while (!done)
            {
                string header = $"{"User Id".PadLeft(10)}{"Username".PadLeft(10)}\n";
                Console.WriteLine(header);
                foreach (User user in differentUsers)
                {
                    Console.WriteLine(user);
                }
                Pause();
                Console.WriteLine();
                Console.WriteLine("Select the User ID of the individual you would like to send money to.");
                string userIdSelectionString = Console.ReadLine();
                if (!userIdSelectionString.IsNullOrEmpty())
                {
                    int userIdSelection = int.Parse(userIdSelectionString);
                    bool test = transferMethods.CheckForValidUserId(userIdSelection, differentUsers);
                    Console.WriteLine();
                    if (test)
                    {
                        Console.WriteLine("Enter the amount of TEBucks you would like to send.");
                        transfer.Amount = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Invalid User ID. Please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Username.");
                }
                Pause();
                Console.WriteLine();
            }
        }
        // Add application-specific UI methods here...
<<<<<<< HEAD
        public void PrintBalance()
        {
            Console.WriteLine();
        }

=======
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
    }
}
