﻿using RestSharp;
using System.Collections.Generic;
using TenmoClient.Models;
namespace TenmoClient.Services
//namespace TenmoServer.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public TenmoApiService(string apiUrl) : base(apiUrl) { }


        public decimal GetBalance()
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

    }
}
