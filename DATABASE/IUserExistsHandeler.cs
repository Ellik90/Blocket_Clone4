using TYPES;
namespace DATABASE;
public interface IUserExistsHandeler
{
    public int UserLogInExists(User user);  // tex IVerifyUserManager ? för dessa
    // public int UserEmailExists(string email);
     public bool UserEmailExists(string email);
    // public int NicknameExists(string nickname);
    public bool NicknameExists(string nickname);
}