using TYPES;
using DATABASE;
namespace LOGIK;
public interface IAdminService
{
    public Admin GetTheAdmin(Admin admin);
    public bool MakeAdmin(Admin admin);
    public bool DeleteAdmin(Admin admin);
    //public bool CheckAdminNameExists(string name); // används ej
    public bool CheckAdminEmailExists(string Email);
    public List<Advertise> GetNonCheckAds();
    public bool UpdateEmail(Admin admin, string adminEmail);

}