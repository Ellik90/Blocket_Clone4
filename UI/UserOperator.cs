using LOGIK;
using TYPES;
using DATABASE;
class UserOperator
{
    IUserService _userService;
    ILogInService _loginService;
    IValidator _validator;
    public UserOperator(ILogInService logInService, IUserService userService, IValidator validator)
    {
        _loginService = logInService;
        _userService = userService;
        _validator = validator;
    }
    public User CreateUser(User user, LogInService logInService)
    {
        bool exists = false;
        do
        {
            user.Email = ConsoleInput.GetString("Enter your email-adress: ");
            if (_userService.CheckUserEmailExists(user.Email))
            {
                Console.WriteLine("Email alredy exists");
                exists = true;
            }
            else
            {
                exists = false;
            }
        } while (exists);
        do
        {
            user.Name = ConsoleInput.GetString("name: ");
            if (_userService.CheckNickNameExists(user.Name))
            {
                Console.WriteLine("name alredy exists");
                exists = true;
            }
            else
            {
                exists = false;
            }
        } while (exists);
        do
        {
            user.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
            if ((_validator.ValidateSocialSecurityNumber(user.SocialSecurityNumber) == false))
            {
                Console.WriteLine("social security number alredy exists");
                exists = true;
            }
            else
            {
                exists = false;
            }
        } while (!exists);

        user = _loginService.MakeNewLogIn(user);
        _userService.MakeUser(user);
        return user;
    }
    public int UserLogIn()
    {
        User user = new();
        user.Email = ConsoleInput.GetString("Enter your Email");
        user.Password = ConsoleInput.GetInt("Enter your Password");
        user = _loginService.UserLogIn(user); //user skriver bara i sin mail och kod
        user.Id = _loginService.UserLogInIsValid(user); //andvänder userhandler och ser om user finns
        return user.Id;
    }
    public void DeleteUser(User user)
    {
        try
        {
            _userService.DeleteTheUser(user);
            Console.WriteLine("Account deleted!");
            Environment.Exit(0);
        }
        catch (MySqlConnector.MySqlException)
        {
            Console.WriteLine("The site is under construction. Try again later.");
        }
    }
    public void UpdateEmail(User user)
    {
        try
        {
            string updateEmail = ConsoleInput.GetString("Update email: ");
            _userService.UpdateEmail(user, updateEmail);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong" + e.Message);
        }
    }
    public void UpdateNickName(User user)
    {
        try
        {
            string updateNickname = ConsoleInput.GetString("nickname: ");
            _userService.UpdateNickname(user, updateNickname);
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong");
        }
    }
    public void UpdatePasswordUser(User user)
    {
        try
        {
            string updatePassword = ConsoleInput.GetString("password ");
            _userService.UpDatePassword(user, updatePassword);
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong");
        }
    }
    public void UpdateDescription(User user)
    {
        string updateDescription = ConsoleInput.GetString("Text: ");
        _userService.UpDateDescription(user, updateDescription);
    }
    public User GetUser(User user)
    {
        user = _userService.GetTheUser(user);
        return user;
    }
}