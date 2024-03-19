using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TenmoServer.Exceptions;
using TenmoServer.Models;

namespace TenmoClient.Models
{
    public class TransferHistoryDTO
    {
        public int TransferId { get; set; }
        public string AccountFromUsername { get; set; }
        public string AccountToUsername { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }

        public override string ToString()
        {
            string TransferIdString = TransferId.ToString();
            string AmountString = Amount.ToString();
            return $"{TransferIdString.PadRight(10)}{AccountFromUsername.PadRight(10)}{AccountToUsername.PadRight(10)}{AmountString.PadRight(10)}";
        }
        
    }
}
