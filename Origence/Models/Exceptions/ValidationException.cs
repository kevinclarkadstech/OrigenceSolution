using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origence.Models.Exceptions
{
    public class ValidationException: Exception
    {
        public IList<string> ValidationErrors { get; private set; } = new List<string>();
        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ValidationException(IList<string> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}
