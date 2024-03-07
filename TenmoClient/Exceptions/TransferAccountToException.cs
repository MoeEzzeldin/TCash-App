using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoClient.Exceptions;

namespace TenmoClient.Exceptions
{
    public class TransferAccountToException : Exception
    {
        public TransferAccountToException() : base() { }
        public TransferAccountToException(string message) : base(message) { }
    }
}
