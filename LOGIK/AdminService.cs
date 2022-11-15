namespace LOGIK;
public class AdminService : IAdminService
{
    IUserHandeler _userHandele;
    IIdentifier _identifier;
    IUserEditor _userEditor;
    IAdmin _admin;

    public AdminService(IIdentifier identifier, IUserHandeler userHandeler, IUserEditor userEditor, IAdmin admin, IAdminEditor adminEditor)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
        _userEditor = userEditor;
        _admin = admin;
    }

     public Admin GetTheAdmin(Admin admin)
    {
       List<Admin> admins = _admin.GetAdmins(admin);

       foreach(Admin item in admins)
       {
        if(item.Id == admin.Id)
        {
            return item;
        }
        else
        {
            Console.WriteLine("something went wrong");
        }        
       }
       return admin;
               
    }

    public bool MakeAdmin(Admin admin)
    {
        int rows = 0;
        _admin.CreateAdmin(admin);
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
        if(rows > 0)
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
    // LÄGG IN METODER
    // updateadminname

}