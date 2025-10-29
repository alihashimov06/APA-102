using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public static string ErrorMessage = "sadfsfs";
        public UserNotFoundException(string username) : base($"User '{username}' not found in the system!")
        {
            
        }
        public UserNotFoundException() : base(ErrorMessage)
        {
            
        }

    }
}
