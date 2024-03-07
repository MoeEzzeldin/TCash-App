using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoServer.Exceptions;

namespace TenmoServer.Models
{
    public class Transfer
    {
        private int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public string TransferTypeDescription { get; set; }
        public int TransferStatusId { get; set; }
        public string TransferStatusDescription { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo
        {
            get
            {
                return AccountTo;
            }
            set
            {
                if (AccountTo != AccountFrom)
                {
                    value = AccountTo;
                }
                else
                {
                    throw new TransferAccountToException("You cannot send yourself TE Bucks");
                }
            } 
        }

        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}
