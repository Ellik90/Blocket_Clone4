namespace LOGIK;
public class AdminOperator 
{
    AdminService _adminService;
    Admin _admin;
    LogInService _loginService;

    public AdminOperator(LogInService logInService, Admin admin, AdminService adminService)
    {
        _loginService = logInService;
        _admin = admin;
        _adminService = adminService;
    }
    public void AdminLogin(Admin admin, LogInService logInService, AdminService adminService)
    {
        admin = new();

        admin.Email = ConsoleInput.GetString("Enter your Email");
        admin.PassWord = ConsoleInput.GetInt("Enter your Password");
        admin = logInService.AdminLogIn(admin); //user skriver bara i sin mail och kod
        admin.Id = logInService.AdminLogInIsValic(admin); //andvänder userhandler och ser om user finns
        if (admin.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
        {
            Console.WriteLine("Fel lösen eller mail");
            Environment.Exit(0);
        }
        admin = adminService.GetTheAdmin(admin);
    }
}