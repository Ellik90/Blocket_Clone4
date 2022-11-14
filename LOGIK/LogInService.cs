namespace LOGIK;
public class LogInService
{
    IIdentifier _identifier;
    IUserHandeler _userHandeler;
    IAdmin _adminHandeler;
    public LogInService(IIdentifier identifier, IUserHandeler userHandeler, IAdmin adminhandeler)
    {
        // för att komma åt det som är i interface för identifier, tex skicka mail
        _identifier = identifier;
        // för att komma åt att validera om kunden finns 
        _userHandeler = userHandeler;
        _adminHandeler = adminhandeler;
    }
    User user = new();
    public User MakeNewLogIn(User user)
    {
        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(user.Email) == true)
        {
            Console.WriteLine("Valid email");
            user.Password = _identifier.SendCodeViaEmail(user.Email);
            Console.WriteLine("Code sent to your mail. Please check junkmail if mail not found.");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
        return user;
    }

    public Admin MakeNewLogIn(Admin admin)
    {
        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(admin.Email) == true)
        {
            Console.WriteLine("Valid email");
            admin.PassWord = _identifier.SendCodeViaEmail(admin.Email);
            Console.WriteLine("Code sent to your mail. Please check junkmail if mail not found.");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
        return admin;
    }

    public User UserLogIn(User user)
    {
        bool isValid = false;

        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(user.Email) == true)
        {
            Console.WriteLine("Valid email");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }

        return user;
    }
    public Admin AdminLogIn(Admin admin)
    {
        bool isValid = false;

        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_identifier.ValidateEmail(admin.Email) == true)
        {
            Console.WriteLine("Valid email");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }

        return admin;
    }
    public int UserLogInIsValid(User user)
    {
        return _userHandeler.UserLogInExists(user);
    }

    public int AdminLogInIsValic(Admin admin)
    {
        return _adminHandeler.AdminLogInExists(admin);
    }

}