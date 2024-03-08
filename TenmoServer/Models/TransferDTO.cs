using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TenmoServer.Exceptions;

namespace TenmoServer.Models
{
    public class TransferDTO
    {
        public int AccountTo { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }        
    }
}
