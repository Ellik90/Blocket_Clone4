namespace LOGIK;
public interface IUserHandeler
{
    public bool NicknameExists(string nickname);
    public bool BecomeNewUser(User user);
    public bool UserLogInExists(User user);  // tex IVerifyUserManager ? för dessa
    public bool UserEmailExists(string email);
    public bool DeleteUser(User deleteUser);
    public bool UpdateEmail(User user, string userEmail);
    public void UpdateNickName(User user, string nickname);
    public void UpDateDescription(User user, string updateDescription);
    
}