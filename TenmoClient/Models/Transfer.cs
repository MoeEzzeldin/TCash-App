using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoClient.Exceptions;

namespace TenmoClient.Models
{
    public class Transfer
    {
        //private int TransferId { get; set; }
        //public int TransferTypeId { get; set; }
        //public string TransferTypeDescription { get; set; }
        //public int TransferStatusId { get; set; }
        //public string TransferStatusDescription { get; set; } = "Approved";
        //public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        //[Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]

        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value > 0M)
                {
                    _amount = value;
                }
                else
                {
                    throw new NonZeroException("Amount must be greater than zero.");
                }
            }
        }

    }
}
