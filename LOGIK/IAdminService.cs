namespace LOGIK;
public interface IAdminService
{
    public Admin GetTheAdmin(Admin admin);
    public bool MakeAdmin(Admin admin);
    public bool DeleteAdmin(Admin admin);
    public bool CheckAdminNameExists(string name);
}