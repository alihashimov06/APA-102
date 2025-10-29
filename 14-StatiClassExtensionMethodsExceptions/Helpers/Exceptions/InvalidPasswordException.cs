using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        public static string ErrorMessage = "dgfs";
        public InvalidPasswordException(string message) : base(message)
        {
            
        }
        public InvalidPasswordException() : base(ErrorMessage)
        {

        }
    }
}
