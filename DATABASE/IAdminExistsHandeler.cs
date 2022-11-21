using TYPES;
namespace DATABASE;
public interface IAdminExistsHandeler
{
    public int AdminLogInExists(Admin admin);
    //public bool AdminNameExists(string name); // Används ej
    public bool AdminEmailExists(string Email);
}