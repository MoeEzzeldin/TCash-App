using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenmoServer.Exceptions;

namespace TenmoServer.Exceptions
{
    public class NonZeroException : Exception
    {
        public NonZeroException() : base() { }
        public NonZeroException(string message) : base(message) { }
    }
}
