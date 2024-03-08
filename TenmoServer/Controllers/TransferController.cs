using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Exceptions;
using TenmoServer.Models;
using TenmoServer.Security;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IBalanceDao balanceDao;
        private readonly IUserDao userDao;

        public TransferController(IBalanceDao balanceDao, IUserDao userDao)
        {
            this.balanceDao = balanceDao;
            this.userDao = userDao;
        }

        [HttpPost]
        public ActionResult UpdateBalances(TransferDTO transfer) 
        {
            User currentUser = userDao.GetUserByUsername(User.Identity.Name);
            if (currentUser == null)
            {
                return NotFound();
            }
            else
            {
                balanceDao.UpdateFromBalance(transfer.Amount, currentUser.UserId);
                balanceDao.UpdateToBalance(transfer.Amount, transfer.AccountTo);
                return Ok();
            }
        }
        [HttpGet]
        public ActionResult<string> Testing()
        {
            return "We're here";
        }
    }
}
