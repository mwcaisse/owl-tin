using System;
using System.Collections.Generic;
using System.Text;

namespace Mitchell.Common.Exceptions
{
    public class QueryException : Exception
    {

        public QueryException()
        {

        }

        public QueryException(string message)
            : base(message)
        {

        }

        public QueryException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
