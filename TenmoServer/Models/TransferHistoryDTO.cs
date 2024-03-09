using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TenmoServer.Exceptions;
namespace TenmoServer.Models
{
    public class TransferHistoryDTO
    {
        //transfer_id, account_from, account_to, amount
        public int TransferId { get; set; }
        //public int AccountFrom { get; set; }
        //public int AccountToUserId { get; set; }
        public string AccountFromUsername { get; set; }
        public string AccountToUsername { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }

        //****ADDED****
        public string TransactionTypeDesc { get; set; }
        public string TransactionStatusDesc { get; set; }



    }
}
