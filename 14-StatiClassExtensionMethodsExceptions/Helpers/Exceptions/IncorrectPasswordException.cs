using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions
{
    internal class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; }
        public static string ErrorMessage = "gdg";
        public IncorrectPasswordException(int attemptsLeft) : base($"Incorrect password! Attempts left: {attemptsLeft}") 
        {
            AttemptsLeft = attemptsLeft;
        }
        
    }
}
