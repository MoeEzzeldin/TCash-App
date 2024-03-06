using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenmoSertver.Models
{
    public class Account
    {
        private int AccountId { get; set; } 
        public int UserId { get; set; }
        public decimal Balance { get; set; } = 1000m;
    }
}
