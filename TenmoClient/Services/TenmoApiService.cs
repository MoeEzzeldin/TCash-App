using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TenmoClient.Models;
namespace TenmoClient.Services
//namespace TenmoServer.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public TenmoApiService(string apiUrl) : base(apiUrl) { }

<<<<<<< HEAD
        public decimal GetBalance() //my balance
=======

        public decimal GetBalance()
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
        {
            RestRequest request = new RestRequest("/account");
            IRestResponse<decimal> response = client.Get<decimal>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<User> GetDifferentUsers() //just added the "I" in front of list.
        {
            RestRequest request = new RestRequest("/tenmo_user");
            IRestResponse<List<User>> response = client.Get<List<User>>(request);
            CheckForError(response);
            return response.Data;
        }
<<<<<<< HEAD
       
        public User CheckForValidUserById(int id)
        {
            RestRequest request = new RestRequest("/tenmo_user/" + id); //this end point may not work!
            IRestResponse<User> response = client.Get<User>(request);
            CheckForError(response);
            return response.Data;
        }

        public Transfer Transfer(Transfer transfer)
=======
<<<<<<< HEAD
<<<<<<< HEAD

=======
        //*********ADDED*********************************
=======
        //****************ADDED*********************************
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
        public Transfer UpdateBalances(Transfer transfer)
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
        {
            RestRequest request = new RestRequest("/transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            CheckForError(response);
            return response.Data;
        }
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
    }
}
