namespace LOGIK;
public class LogInService
{
    IIdentifier _identifier;
    IUserHandeler _userHandeler;
    public LogInService(IIdentifier identifier, IUserHandeler userHandeler)
    {
        // för att komma åt det som är i interface för identifier, tex skicka mail
        _identifier = identifier;
        // för att komma åt att validera om kunden finns 
        _userHandeler = userHandeler;
    }
    User user = new();
    public User MakeNewLogIn(User user)
    {
        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(user.Email) == true )// && _userhandeler.UserEmailExists(user.Email) == true)
        {
            Console.WriteLine("Valid email");
            user.Password = _identifier.SendEmailWithCode(user.Email);
            Console.WriteLine("Code sent to your mail. Please check junkmail if mail not found.");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
        return user;
    }

    public User UserLogIn()
    {
        User user = new();
        bool isValid = false;
     //    user.Email = ConsoleInput.GetString("Enter your mail-adress");
        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(user.Email) == true)
        {
            Console.WriteLine("Valid email");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
//        user.Password = ConsoleInput.GetString("Enter your password");
       return user;
    }
    public bool UserIsValid(User user)
    {
        return _userHandeler.UserExists(user);
    }

}