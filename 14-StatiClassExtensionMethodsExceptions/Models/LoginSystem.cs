using System;
using _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions;
namespace _14_StatiClassExtensionMethodsExceptions.Models
{
    internal class LoginSystem
    {
        public User[] users;
        public const int MaxAttempts = 3;
        public LoginSystem()
        {
            users = new User[3];
            users[0] = new User("admin", "admin123");
            users[1] = new User("student", "student123");
            users[2] = new User("teacher", "teacher123");
        }
        public void ValidateUsername(string username)
        {
            if (username.Length < 3 && username == null)
            {

                throw new InvalidUsernameExceeption();
            
            }
            

        }
        public void ValidatePassword(string password)
        {
            if (password.Length < 6 && password == null)
                throw new InvalidPasswordException();
        }
        private User FindUser(string username)
        {
            for (int i = 0; i < username.Length; i++)
            {
                if (users[i].Username.ToLower() == username.ToLower())
                {
                    return users[i];
                }
            }
            return null;
        }
        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            User user = FindUser(username);

            if (user == null)
                throw new UserNotFoundException(username);

            if (user.IsLocked)
                throw new AccountLockedException();

            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {user.Username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;
                int attemptsLeft = MaxAttempts - user.FailedAttempts;

                if (attemptsLeft > 0)
                    throw new IncorrectPasswordException(attemptsLeft);
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
        }

        internal void ShowAllUsers()
        {
            throw new NotImplementedException();
        }
    }

}
