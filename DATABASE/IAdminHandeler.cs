using TYPES;
namespace DATABASE;
public interface IAdminHandeler
{
    public int CreateAdmin(Admin admin);
    public int DeleteAdmin(Admin admin);
    public List<Admin> GetAdmins(Admin admin );
         
}