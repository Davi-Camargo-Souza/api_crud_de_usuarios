using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.Shared.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() { }
        public WrongPasswordException(string message) : base(message)
        {
        }

        public WrongPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
