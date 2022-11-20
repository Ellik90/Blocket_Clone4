using LOGIK;
using TYPES;
using DATABASE;

public class AdminOperator
{
    IAdminEditor _adminEditor;
    IUserService _userService;
    IAdminService _adminService;
    ILogInService _loginService;
    IValidator _validator;

    public AdminOperator(ILogInService logInService, IAdminService adminService, IUserService userService, IAdminEditor adminEditor, IValidator validator)
    {
        _adminEditor = adminEditor;
        _userService = userService;
        _loginService = logInService;
        _adminService = adminService;
        _validator = validator;
    }  
    public void DeleteAdmin(Admin admin)
    {
        try
        {
            _adminService.DeleteAdmin(admin);
            Console.WriteLine("Account deleted!");
            Environment.Exit(0);
        }
        catch (MySqlConnector.MySqlException)
        {
            Console.WriteLine("The site is under construction. Try again later.");
        }
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
    public Admin CreateAdmin(Admin admin)
    {
        bool exists = false;
        do
        {
        admin.Email = ConsoleInput.GetString("Enter your mail-adress");
        if (_adminService.CheckAdminEmailExists(admin.Email))
        {
            Console.WriteLine("Email allready exists");
            exists = true;
        }
        else
        {
            exists = false;
        }
        }while (exists);

        admin.Name = ConsoleInput.GetString("name: ");

        do
        {
        admin.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
        if (_validator.ValidateSocialSecurityNumber(admin.SocialSecurityNumber) == false)
        {
            Console.WriteLine("Social security number incorrect");
            exists = true;
        }
        }while (exists);
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