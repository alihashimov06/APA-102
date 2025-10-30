using _14_StatiClassExtensionMethodsExceptions.Helpers.Exceptions;
using _14_StatiClassExtensionMethodsExceptions.Models;

LoginSystem system = new LoginSystem();

while (true)
{
    Console.Write("Enter username: ");
    string username = Console.ReadLine();

    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    try
    {
        if (system.Login(username, password))
            break;
    }
    catch (InvalidUsernameExceeption ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
    }
    catch (InvalidPasswordException ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
    }
    catch (UserNotFoundException ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
        system.ShowAllUsers();
    }
    catch (IncorrectPasswordException ex)
    {
        Console.WriteLine("WARNING: " + ex.Message);
    }
    catch (AccountLockedException ex)
    {
        Console.WriteLine("CRITICAL: " + ex.Message + " Please contact admin.");
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
    }

    Console.WriteLine("-----------------------------------");
}

Console.WriteLine("Program ended.");



