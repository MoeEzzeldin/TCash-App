
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
        public int AccountTo { get; set; }

        private decimal _amount;
<<<<<<< HEAD
=======
=======
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
<<<<<<< HEAD

=======
=======
        public int AccountTo { get; set; }
        //[Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
>>>>>>> db10b0f8eb680cbe271b01c6a6df800c7a74a3ec
>>>>>>> 2a0a391cde59029b6bbdb6a9b3f4667df6c3b566
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
<<<<<<< HEAD

                if (value > 0M)
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
                if (value > 0M)
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> db10b0f8eb680cbe271b01c6a6df800c7a74a3ec



                if (value > 0)
<<<<<<< HEAD
=======
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
>>>>>>> db10b0f8eb680cbe271b01c6a6df800c7a74a3ec
>>>>>>> 2a0a391cde59029b6bbdb6a9b3f4667df6c3b566
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
