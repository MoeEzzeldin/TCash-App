using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services;


namespace TenmoClient
{
    public class TenmoApp
    {
        private readonly TenmoConsoleService console = new TenmoConsoleService();
        private readonly TenmoApiService tenmoApiService;
        //private readonly AuthenticatedApiService authenticatedApiService = new AuthenticatedApiService();

        public TenmoApp(string apiUrl)
        {
            tenmoApiService = new TenmoApiService(apiUrl);
        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (tenmoApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            console.PrintLoginMenu();
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console.PrintError("Invalid selection. Please choose an option.");
                console.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            console.PrintMainMenu(tenmoApiService.Username);
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {

                GetBalance();

            }

            if (menuSelection == 2)
            {
                // View your past transfers
            }

            if (menuSelection == 3)
            {
                // View your pending requests
            }

            if (menuSelection == 4)
            {
                //Send TE Bucks
           
                int userInput = console.GetsUserIdToSendMoneyTo(tenmoApiService.GetDifferentUsers()); //Step 1: Testing for valid userId
                //TestingForValidUserId(userInput); //Step 1: Testing for valid userId.
                decimal userToAmount = console.PromptingUserForAmountToSend(); //Step 2: No logic for <=0 needed because of setter condition. 
                {
                    Transfer transfer = new Transfer();
                    transfer.AccountTo = userInput;
                    transfer.Amount = userToAmount;
                    if (CreateNewTransfer(transfer) == true)
                    {
                        console.Success(transfer.Amount);
                    }
                    console.Pause();
                } 
            }

            if (menuSelection == 5)
            {
                // Request TE bucks
                DisplayTransactions();
            }

            if (menuSelection == 6)
            {
                // Log out
                tenmoApiService.Logout();
                console.PrintSuccess("You are now logged out");
            }

            return true; // Keep the main menu loop going
        }

        private void Login()
        {
            LoginUser loginUser = console.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = tenmoApiService.Login(loginUser);
                if (user == null)
                {
                    console.PrintError("Login failed.");
                }
                else
                {
                    console.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console.PrintError("Login failed.");
            }
            console.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = console.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = tenmoApiService.Register(registerUser);
                if (isRegistered)
                {
                    console.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console.PrintError("Registration was unsuccessful.");
            }
            console.Pause();
        }

        private void GetBalance()
        {
            try
            {
                decimal balance = tenmoApiService.GetBalance();
                console.PrintBalance(balance);
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }
        public bool CreateNewTransfer(Transfer transfer)
        {
            bool result = false;
            try
            {
                tenmoApiService.Transfer(transfer);
                result = true;
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
                result = false;
            }
            return result;
            //console.Pause();
        }
        public void DisplayTransactions()
        {
            try
            {
                List<TransferHistoryDTO> listOfTransactions = tenmoApiService.GetTransactions();
                console.PrintTransactionDetails(listOfTransactions);
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }
        //private bool 
    }
}
