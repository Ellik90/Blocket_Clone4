using TYPES;
using DATABASE;
namespace LOGIK;
public class LogInService : ILogInService
{
    // IIdentifier _identifier;
    IUserHandeler _userHandeler;
    IAdmin _adminHandeler;
    IValidator _validator;
    IEmailSender _emailSender;
    public LogInService(IUserHandeler userHandeler, IAdmin adminhandeler, IValidator validator, IEmailSender emailSender)
    {
        // för att komma åt det som är i interface för identifier, tex skicka mail
        // _identifier = identifier;
        // för att komma åt att validera om kunden finns 
        _userHandeler = userHandeler;
        _adminHandeler = adminhandeler;
        _validator = validator;
        _emailSender = emailSender;
    }
    User user = new();
    public User MakeNewLogIn(User user)
    {
        //här anropar jag metoden och skickar in mailadressen som kommer in, denna metoden returnerar antingen true eller false 
        if (_validator.ValidateEmail(user.Email) == true)
        {
            Console.WriteLine("Valid email");
            user.Password = _emailSender.SendCodeViaEmail(user.Email);
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
        if (_validator.ValidateEmail(admin.Email) == true)
        {
            Console.WriteLine("Valid email");
            admin.PassWord = _emailSender.SendCodeViaEmail(admin.Email);
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
        if (_validator.ValidateEmail(user.Email) == true)
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
        if (_validator.ValidateEmail(admin.Email) == true)
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

    public int AdminLogInIsValid(Admin admin)
    {
        return _adminHandeler.AdminLogInExists(admin);
    }

}