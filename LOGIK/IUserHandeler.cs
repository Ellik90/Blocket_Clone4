namespace LOGIK;
public interface IUserHandeler
{
    public bool NicknameExists(string nickname);
    public void BecomeNewUser(User user);
    public bool UserExists(User user);  // tex IVerifyUserManager ? för dessa
    public bool DeleteUser(User deleteUser);
    public bool UpdateEmail(User user, string userEmail);
    public void UpdateNickName(User user, string nickname);
    public void UpDateDescription(User user, string updateDescription);
    
}