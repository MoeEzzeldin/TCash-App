using RestSharp;
using System.Collections.Generic;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public TenmoApiService(string apiUrl) : base(apiUrl) { }

        // Add methods to call api here...
        //public decimal GetBalance(int accountId)
        //{
        //    RestRequest request = new RestRequest("account/" + accountId);
        //    IRestResponse<Account> response = client.Get<Account>(request);
        //    CheckForError(response);
        //    return response.Data.Balance;
        //}
        //public decimal GetBalance(int userId)
        //{
        //    RestRequest request = new RestRequest("account/" + userId);
        //    IRestResponse<Account> response = client.Get<Account>(request);
        //    CheckForError(response);
        //    return response.Data.Balance;
        //}
        public decimal GetBalance()
        {
            RestRequest request = new RestRequest("/account");
            IRestResponse<decimal> response = client.Get<decimal>(request);
            CheckForError(response);
            return response.Data;
        }
    }
}
