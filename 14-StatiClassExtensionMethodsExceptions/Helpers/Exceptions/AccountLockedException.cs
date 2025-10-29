using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions
{
    internal class AccountLockedException : Exception
    {
        public static string ErrorMessage = "Account is locked due to too many failed login attempts!";
        
        public AccountLockedException(string message) : base(message)
        {

        }
        public AccountLockedException() : base(ErrorMessage)
        {

        }
    }
}
