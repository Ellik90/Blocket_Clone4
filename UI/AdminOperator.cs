namespace LOGIK;
public class AdminOperator
{
    IAdminEditor _adminEditor;
    IuserService _userService;
    IAdminService _adminService;
    Admin _admin;
    ILogInService _loginService;
    IIdentifier _identifier;

    public AdminOperator(ILogInService logInService, IAdminService adminService, IuserService userService, IAdminEditor adminEditor, IIdentifier identifier)
    {
        _adminEditor = adminEditor;
        _userService = userService;
        _loginService = logInService;
        // _admin = admin;
        _adminService = adminService;
        _identifier = identifier;
    }

    public void UpdateEmail(Admin admin)
    {
        try
        {
            string updateEmail = ConsoleInput.GetString("Update email: ");
            _adminService.UpdateEmail(admin, updateEmail);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong " + e.Message);
        }
    }


    public Admin CreateAdmin(AdminDB adminDB)
    {
        Admin admin = new();
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
        if (_identifier.ValidateSocialSecurityNumber(admin.SocialSecurityNumber) == false)
        {
            Console.WriteLine("Social security number incorrect");
            Environment.Exit(0);
        }
        admin = _loginService.MakeNewLogIn(admin);
        _adminService.MakeAdmin(admin);
        return admin;
    }

    public int AdminLogin()
    {
        Admin admin = new();

        admin.Email = ConsoleInput.GetString("Enter your Email");
        admin.PassWord = ConsoleInput.GetInt("Enter your Password");
        admin = _loginService.AdminLogIn(admin); //user skriver bara i sin mail och kod
        admin.Id = _loginService.AdminLogInIsValid(admin); //andvänder userhandler och ser om user finns

        return admin.Id;
    }

    public void GetNonCheckedAds()
    {
        List<Advertise> nonCheckedAds = _adminService.GetNonCheckAds();
        foreach (Advertise item in nonCheckedAds)
        {
            Console.WriteLine(item.ToString());
        }
    }


}