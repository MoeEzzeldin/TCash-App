using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoClint.Exceptions;

namespace TenmoClient.Models
{
    public class Transfer
    {
        private int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public string TransferTypeDescription { get; set; }
        public int TransferStatusId { get; set; }
        public int TransferStatusDescription { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo
        {
            get
            {
                return AccountTo;
            }
            set
            {
                if(AccountTo != AccountFrom)
                {
                    
                }
                else
                {
                    throw new TransferAccountToException("You Cant Send Yourself TEbucks, Please Select The Currect Username");
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
                if(Amount == 0)
                {
                    throw new NonZeroException("Amount Must Be Greater Than (0)");
                }
            }
        }
    }
}
