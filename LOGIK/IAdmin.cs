namespace LOGIK;
public interface IAdmin
{
    public int CreateAdmin(Admin admin);
    public int DeleteAdmin(Admin admin);
    public List<Admin> GetAdmins(Admin admin );
     
}