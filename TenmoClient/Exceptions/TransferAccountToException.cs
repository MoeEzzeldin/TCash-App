﻿using System;

namespace TenmoClint.Exceptions
{
    public class TransferAccountToException : Exception
    {
        public TransferAccountToException() : base() { }
        public TransferAccountToException(string message) : base(message) { }
        public TransferAccountToException(string message, Exception inner) : base(message, inner) { }
    }
}
