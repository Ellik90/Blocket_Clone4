namespace LOGIK;
public class AdminOperator
{
    IuserService _userService;
    IAdminService _adminService;
    Admin _admin;
    LogInService _loginService;

    public AdminOperator(LogInService logInService, IAdminService adminService, IuserService userService)
    {
        _userService = userService;
        _loginService = logInService;
       // _admin = admin;
        _adminService = adminService;
    }

  
        public static Admin CreateAdmin(Admin admin, AdminDB adminDB, LogInService logInService, Identifier identifier)
        {
            admin.Email = ConsoleInput.GetString("Enter your mail-adress");
            if (adminDB.AdminEmailExists(admin.Email) > 0)
            {
                Console.WriteLine("Email allready exists");
                Environment.Exit(0);
            }
            //<-här har user med sig email, lösenord|elina tar över user och gör resten
            admin.Name = ConsoleInput.GetString("name: ");
            if (adminDB.AdminNameExists(admin.Name) > 0)
            {
                Console.WriteLine("Nickname allready exists");
                Environment.Exit(0);
            }
            admin.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
            if (identifier.ValidateSocialSecurityNumber(admin.SocialSecurityNumber) == false)
            {
                Console.WriteLine("Social security number incorrect");
                Environment.Exit(0);
            }
            admin = logInService.MakeNewLogIn(admin);
            return admin;
        }
    
    public void AdminLogin(Admin admin, LogInService logInService, AdminService adminService)
    {
        admin = new();

        admin.Email = ConsoleInput.GetString("Enter your Email");
        admin.PassWord = ConsoleInput.GetInt("Enter your Password");
        admin = logInService.AdminLogIn(admin); //user skriver bara i sin mail och kod
        admin.Id = logInService.AdminLogInIsValid(admin); //andvänder userhandler och ser om user finns
        if (admin.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
        {
            Console.WriteLine("Fel lösen eller mail");
            Environment.Exit(0);
        }
        admin = adminService.GetTheAdmin(admin);
    }


}