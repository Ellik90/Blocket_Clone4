namespace LOGIK;
public interface IUserHandeler
{
    public bool NicknameExists(string nickname);
    public bool BecomeNewUser(User user);
    public int UserLogInExists(User user);  // tex IVerifyUserManager ? för dessa
    public bool UserEmailExists(string email);
    public bool DeleteUser(User user);
    public bool UpdateEmail(User user, string userEmail);
    public bool UpdateNickName(User user, string nickname);
    public bool UpDateDescription(User user, string updateDescription);
    public int GetUserIdFromAdvertise(int advertiseId);
    
}