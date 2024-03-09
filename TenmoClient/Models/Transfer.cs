
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
