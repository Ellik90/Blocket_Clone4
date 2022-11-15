namespace LOGIK;
public class Admin 
{

    public int Id { get; set; }
    public string? SocialSecurityNumber { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? adminRole { get; set; }
    public int PassWord { get; set; }
    public readonly DateTime Openaccount;

    public Admin(int id, string socialsecuritynumber, string name, string email, string role, int passWord)
    {
        Openaccount = DateTime.Now;
    }
    public Admin()
    {

    }

    public int CreateAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public int DeleteAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetAdmins(Admin admin)
    {
        throw new NotImplementedException();
    }

    public int AdminLogInExists(Admin admin)
    {
        throw new NotImplementedException();
    }

    public int AdminNameExists(string name)
    {
        throw new NotImplementedException();
    }
}