using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoClient.Exceptions;

namespace TenmoClient.Models
{
    public class Transfer
    {
        private int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public string TransferTypeDescription { get; set; }
        public int TransferStatusId { get; set; }
        public string TransferStatusDescription { get; set; } = "Approved";
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
        public decimal Amount
        {
            get
            {
                return Amount;
            }
            set
            {
                if (Amount > 0)
                {
                    value = Amount;
                }
                else
                {
                    throw new NonZeroException("Amount must be greater than zero.");
                }
            }
        }

    }
}
