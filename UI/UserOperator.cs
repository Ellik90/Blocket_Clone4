namespace LOGIK;
class UserOperator
{
    IUserEditor _userEditor;
    IuserService _userService;
    User _user;
    ILogInService _loginService;


    public UserOperator(ILogInService logInService, User user, UserService userService)
    {
        _loginService = logInService;
        _user = user;
        _userService = userService;
    }

    public User CreateUser(User user, LogInService logInService, UserDB userdb, Identifier identifier)
    {
        user.Email = ConsoleInput.GetString("Enter your mail-adress");
        if (userdb.UserEmailExists(user.Email) > 0)
        {
            Console.WriteLine("Email allready exists");
            Environment.Exit(0);
        }
        //<-här har user med sig email, lösenord|elina tar över user och gör resten
        user.Name = ConsoleInput.GetString("name: ");
        if (userdb.NicknameExists(user.Name) > 0)
        {
            Console.WriteLine("Nickname allready exists");
            Environment.Exit(0);
        }
        user.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
        if (identifier.ValidateSocialSecurityNumber(user.SocialSecurityNumber) == false)
        {
            Console.WriteLine("Social security number incorrect");
            Environment.Exit(0);
        }
        user.Adress = ConsoleInput.GetString("adress: "); //FÖR USER HAR EMAIL HÄR // och password
        user = _loginService.MakeNewLogIn(user);    
        _userService.MakeUser(user); // FELHANTERING MED BOOLEN?                 //user = new(input, num, adress, email, password);
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
            _userEditor.UpdateEmail(user, updateEmail);
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong");
        }
    }

    public void UpdateNickName(User user)
    {
        try
        {
            string updateNickname = ConsoleInput.GetString("nickname: ");
            _userEditor.UpdateNickName(user, updateNickname);
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong");
        }
    }

    public void UpdateDescription(User user)
    {
        string updateDescription = ConsoleInput.GetString("Text: ");
        _userEditor.UpDateDescription(user, updateDescription);
    }

    public User GetUser(User user)
    {
        _userService.GetTheUser(user);
        return user;
    }

}