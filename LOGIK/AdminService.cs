namespace LOGIK;
public class AdminService
{
    IUserHandeler _userHandele;
    IIdentifier _identifier;
    IUserEditor _userEditor;

    public AdminService(IIdentifier identifier, IUserHandeler userHandeler, IUserEditor userEditor)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
        _userEditor = userEditor;
    }
  // LÄGG IN METODER
       

}