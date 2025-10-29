using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions
{
    internal class InvalidUsernameExceeption : Exception
    {
        public static string ErrorMessage = "sdfsfs";
        public InvalidUsernameExceeption(string message) : base(message)
        {
            
        }
        public InvalidUsernameExceeption() : base(ErrorMessage) 
        {
            
        }
    }
}
