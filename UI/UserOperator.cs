namespace LOGIK;
class UserOperator
{
    IuserService _userService;
    User _user;
    LogInService _loginService;

    public UserOperator(LogInService logInService, User user, UserService userService)
    {
        _loginService = logInService;
        _user = user;
        _userService = userService;
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