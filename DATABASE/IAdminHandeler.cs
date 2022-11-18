using TYPES;
namespace DATABASE;
public interface IAdminHandeler
{
    public int CreateAdmin(Admin admin);
    public int DeleteAdmin(Admin admin);
    public List<Admin> GetAdmins(Admin admin );
     public int AdminLogInExists(Admin admin);    
     public int AdminNameExists(string name); //fungerar dessa två?
     public int AdminEmailExists(string Email);
}