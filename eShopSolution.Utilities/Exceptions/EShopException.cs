using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Utilities.Exceptions
{
    public class EShopException : Exception
    {
        public EShopException()
        {

        }
        public EShopException(string Message)
            : base(Message)
        {

        }
        public EShopException(string Message, Exception inner)
            : base(Message, inner)
        {

        }
    }
}
