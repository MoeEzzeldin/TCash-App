﻿using System;
using TenmoServer.Exceptions;

namespace TenmoServer.Exceptions
{
    public class TransferAccountToException : Exception
    {
        public TransferAccountToException() : base() { }
        public TransferAccountToException(string message) : base(message) { }
    }
}
