﻿using System;

namespace TenmoClint.Exceptions
{
    public class NonZeroException : Exception
    {
        public NonZeroException() : base() { }
        public NonZeroException(string message) : base(message) { }
        public NonZeroException(string message, Exception inner) : base(message, inner) { }
    }
}
