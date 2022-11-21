using TYPES;
using DATABASE;
namespace LOGIK;
public interface IIdentifier
{
    public bool ValidateSocialSecurityNumber(string socNo);
    public bool ValidateEmail(string email);
    public int SendCodeViaEmail(string email);
    public bool CheckIfUserExists(IUserExistsHandeler userExists, User user);  
    public int GenerateUniqueCode();
}