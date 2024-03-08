﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly ITransferDao transferDao;

        public TransferController(IBalanceDao balanceDao, IUserDao userDao, ITransferDao transferDao)
        {
            this.balanceDao = balanceDao;
            this.userDao = userDao;
            this.transferDao = transferDao;
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
                //transferDao.CreateNewTransfer(transfer); with Transfer object argument in controller.
                IList<User> differentUsers = new List<User>();
                differentUsers = userDao.GetDifferentUsers(currentUser.Username);
                foreach (User user in differentUsers) //we shouldn't need the conditionals anymore for making sure userId matches. that's handled elsewhere.
                {
                    if (transfer.AccountTo == user.UserId)
                    {
                        if (balanceDao.GetBalanceByUserId(currentUser.UserId) - transfer.Amount >= 0)
                        {
                            transferDao.CreateNewTransfer(transfer.AccountTo, currentUser.UserId, transfer.Amount);
                            balanceDao.UpdateFromBalance(transfer.Amount, currentUser.UserId);
                            balanceDao.UpdateToBalance(transfer.Amount, transfer.AccountTo);
                            return Ok();

                        }
                        else
                        {
                            return Content("Insufficient funds.");
                        }
                    }
                }
                return NotFound();
            }

        }
    }
}
