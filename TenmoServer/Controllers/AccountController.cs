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

        [HttpGet("{userId}")]
        public ActionResult<decimal> GetBalance(int accountId)
        {
            User currentUser = UserD
            return balanceDao.GetBalanceByAccountId(accountId); //so here, we'll need to get the accountId from the userId.
        }
        //User currentUser = userDao.GetUserByUsername(User.Identity.Name);
        //pet.Owner = currentUser.UserId;
        //    pet.OwnerName = currentUser.Username;
        //    Pet addedPet = dao.AddAPet(pet);
        //    return Created("/pet", addedPet);
    }
}
