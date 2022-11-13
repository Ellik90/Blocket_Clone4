namespace LOGIK;
public class AdminService
{
    IUserHandeler _userHandele;
    IIdentifier _identifier;
    IUserEditor _userEditor;
    IAdmin _admin;

    public AdminService(IIdentifier identifier, IUserHandeler userHandeler, IUserEditor userEditor, IAdmin admin)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
        _userEditor = userEditor;
        _admin = admin;
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
  // LÄGG IN METODER
       

}