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
    public class UserController : ControllerBase
    {
        private readonly IBalanceDao balanceDao;
        private readonly IUserDao userDao;

        public UserController(IBalanceDao balanceDao, IUserDao userDao)
        {
            this.balanceDao = balanceDao;
            this.userDao = userDao;
        }
        [HttpGet("/tenmo_user")]
        public ActionResult<List<User>> GetDifferentUsers()
        {
            string username = User.Identity.Name;
            IList<User> list = userDao.GetDifferentUsers(username);
            //if (list.Count > 0)
            //{
            //    return Ok(list);
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok(list);
        }
    }
}
