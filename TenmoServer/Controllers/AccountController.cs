using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security;
namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IBalanceDao balanceDao;
        public AccountController(IBalanceDao balanceDao)
        {
            this.balanceDao = balanceDao;
        }
        ////GET /
        //[HttpGet("/")]
        //public ActionResult<string> Ready()
        //{
        //    return Ok("Server is ready!");
        //}

        [HttpGet("{accountId}")]
        public ActionResult <decimal>  GetBalance(int accountId)
        {
            return balanceDao.GetBalanceByAccountId(accountId);
        }

    }
}
