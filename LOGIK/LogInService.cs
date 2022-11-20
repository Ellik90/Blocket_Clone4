using TYPES;
using DATABASE;
namespace LOGIK;
public class LogInService : ILogInService
{

    IUserExistsHandeler _userExistsHandeler;
    IAdminHandeler _adminHandeler;
    IValidator _validator;
    IEmailSender _emailSender;

    public LogInService(IAdminHandeler adminhandeler, IValidator validator, IEmailSender emailSender, IUserExistsHandeler userExistsHandeler)
    {
        _userExistsHandeler = userExistsHandeler;
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
    public User SendNewCode(User user)
    {
        user.Password = _emailSender.SendCodeViaEmail(user.Email);
        return user;
    }
    public int UserLogInIsValid(User user)
    {
        return _userExistsHandeler.UserLogInExists(user);
    }
    public int AdminLogInIsValid(Admin admin)
    {
        return _adminHandeler.AdminLogInExists(admin);
    }

}