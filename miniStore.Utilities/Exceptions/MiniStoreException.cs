using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Utilities.Exceptions
{
    public class MiniStoreException : Exception
    {
        public MiniStoreException()
        {
        }

        public MiniStoreException(string message)
            : base(message)
        {
        }

        public MiniStoreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
