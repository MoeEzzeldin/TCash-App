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
        public decimal GetBalance() //my balance
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
        public Transfer Transfer(Transfer transfer)
=======
<<<<<<< HEAD
=======
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
>>>>>>> db10b0f8eb680cbe271b01c6a6df800c7a74a3ec

        public Transfer UpdateBalances(Transfer transfer)
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
>>>>>>> 2a0a391cde59029b6bbdb6a9b3f4667df6c3b566
        {
            RestRequest request = new RestRequest("/transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            CheckForError(response);
            return response.Data;
        }
<<<<<<< HEAD
        public List<TransferHistoryDTO> GetTransactions() //just added the "I" in front of list.
        {
            RestRequest request = new RestRequest("/transfer_history");
            IRestResponse<List<TransferHistoryDTO>> response = client.Get<List<TransferHistoryDTO>>(request);
            CheckForError(response);
            return response.Data;
        }
=======
>>>>>>> 2a0a391cde59029b6bbdb6a9b3f4667df6c3b566
    }
}
