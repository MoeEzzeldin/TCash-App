
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
<<<<<<< HEAD
        //private int TransferId { get; set; }
        //public int TransferTypeId { get; set; }
        //public string TransferTypeDescription { get; set; }
        //public int TransferStatusId { get; set; }
        //public string TransferStatusDescription { get; set; } = "Approved";
        //public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        //[Range(0.01, Double.PositiveInfinity, ErrorMessage = "Price must be greater than 0.")]

        private decimal _amount;
=======
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
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
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
<<<<<<< HEAD

                if (Amount != 0)
=======
                if (Amount > 0)
>>>>>>> cdf271372f87d1ad07f59f8a02744bd9148116b9
=======
                if (value > 0)
>>>>>>> 406b8cdde3f40ba55ac9798a21a877685ae4c810
>>>>>>> dca2a08edb7ed7ebe22cef4144aab7ac33bd7d91
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
