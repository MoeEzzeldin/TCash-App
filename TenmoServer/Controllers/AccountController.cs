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
        private IUserDao userDao;

        public AccountController(IBalanceDao balanceDao, IUserDao userDao)
        {
            this.balanceDao = balanceDao;
            this.userDao = userDao;
        }


        [HttpGet]
        public ActionResult<decimal> GetBalance()
        {
            User currentUser = userDao.GetUserByUsername(User.Identity.Name);
            return balanceDao.GetBalanceByAccountId(currentUser.UserId);
        }

    }
}
