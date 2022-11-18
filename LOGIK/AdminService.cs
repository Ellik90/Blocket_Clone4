using TYPES;
using DATABASE;
namespace LOGIK;
public class AdminService : IAdminService
{
    IAdminEditor _adminEditor;
    IUserHandeler _userHandele;
    IUserEditor _userEditor;
    IAdHandler _adHandeler;
    IAdminHandeler _admin;

    public AdminService(IUserHandeler userHandeler, IUserEditor userEditor, IAdminHandeler admin, IAdminEditor adminEditor, IAdHandler adHandler)
    {
        _userHandele = userHandeler;
        _userEditor = userEditor;
        _admin = admin;
        _adHandeler = adHandler;
        _adminEditor = adminEditor;
    }

    public bool UpdateEmail(Admin admin, string adminEmail)
    {
        int rows = 0;
        _adminEditor.UpdateAdminEmail(admin, adminEmail);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Admin GetTheAdmin(Admin admin)
    {
        List<Admin> admins = _admin.GetAdmins(admin);

        foreach (Admin item in admins)
        {
            if (item.Id == admin.Id)
            {
                return item;
            }
        }
        return admin;
    }

    public bool MakeAdmin(Admin admin)
    {
        int rows = 0;
        rows = _admin.CreateAdmin(admin);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DeleteAdmin(Admin admin)
    {
        int rows = 0;
        _admin.DeleteAdmin(admin);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckAdminNameExists(string name)
    {
        int rows = 0;
        _admin.AdminNameExists(name); //name admin
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckAdminEmailExists(string Email)
    {
        int rows = 0;
        _admin.AdminEmailExists(Email);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Advertise> GetNonCheckAds()
    {
        List<Advertise> allAdvertises = _adHandeler.ShowAllAds();
        List<Advertise> nonCheckedAds = new();
        foreach (Advertise item in allAdvertises)
        {
            if (item.isChecked == false)
            {
                nonCheckedAds.Add(item);
            }
        }
        return nonCheckedAds;
    }
    // LÄGG IN METODER
    // updateadminname

}