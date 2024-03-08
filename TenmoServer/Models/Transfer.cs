using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Exceptions;

namespace TenmoServer.Models
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public string TransferTypeDescription { get; set; }
        public int TransferStatusId { get; set; }
        public string TransferStatusDescription { get; set; }
        public int AccountFrom { get; set; }
<<<<<<< HEAD
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
<<<<<<< HEAD
        public decimal Amount
        {
            get
            {
                return Amount;
            }
            set
            {

                if (Amount != 0)
                {
                    value = Amount;
                }
                else
                {
                    throw new NonZeroException("Amount must be greater than zero.");
                }
            }
        }
=======
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
=======
        public int AccountTo { get; set; }

>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810

        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}
