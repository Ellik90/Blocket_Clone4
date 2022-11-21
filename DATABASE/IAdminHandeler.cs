using TYPES;
namespace DATABASE;
public interface IAdminHandeler
{
    public int CreateAdmin(Admin admin);
    public int DeleteAdmin(Admin admin);
    public List<Admin> GetAdmins(Admin admin );
    // public int AdminLogInExists(Admin admin);    
     //public bool AdminNameExists(string name); // Används ej
     //public bool AdminEmailExists(string Email);
     
}