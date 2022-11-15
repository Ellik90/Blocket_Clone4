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
        user = logInService.MakeNewLogIn(user);                       //user = new(input, num, adress, email, password);
        return user;
    }


    public void UserLogIn(User user, LogInService logInService, UserService userService)
    {
        user = new();
        user.Email = ConsoleInput.GetString("Enter your Email");
        user.Password = ConsoleInput.GetInt("Enter your Password");
        user = logInService.UserLogIn(user); //user skriver bara i sin mail och kod
        user.Id = logInService.UserLogInIsValid(user); //andvänder userhandler och ser om user finns
        if (user.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
        {
            Console.WriteLine("Fel lösen eller mail");
            Environment.Exit(0);
        }
        user = userService.GetTheUser(user);
    }
    

}