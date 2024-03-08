
﻿using System;
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
        private int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public string TransferTypeDescription { get; set; }
        public int TransferStatusId { get; set; }
<<<<<<< HEAD


        public string TransferStatusDescription { get; set; }
=======
        public string TransferStatusDescription { get; set; } = "Approved";
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
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
=======
        public int AccountTo { get; set; }
        //[Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
        public decimal Amount
        {
            get
            {
                return Amount;
            }
            set
            {
<<<<<<< HEAD
<<<<<<< HEAD

                if (Amount != 0)
=======
                if (Amount > 0)
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
=======
                if (value > 0)
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
                {
                    Amount = value;
                }
                else
                {
                    throw new NonZeroException("Amount must be greater than zero.");
                }
            }
        }

    }
}
