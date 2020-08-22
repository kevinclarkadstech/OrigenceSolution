using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origence.Models.Exceptions
{
    public class BadInputException: System.Exception
    {
        public BadInputException()
        {
        }

        public BadInputException(string message)
            : base(message)
        {
        }

        public BadInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
