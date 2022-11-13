namespace LOGIK;
public interface IUserHandeler
{
    public int NicknameExists(string nickname);
    public int CreateUser(User user);
    public int UserLogInExists(User user);  // tex IVerifyUserManager ? för dessa
    public int UserEmailExists(string email);
    public int DeleteUser(User user);
    public int UpdateEmail(User user, string userEmail);
    public int UpdateNickName(User user, string nickname);
    public int UpDateDescription(User user, string updateDescription);
    public int GetUserIdFromAdvertise(int advertiseId);
    public List<User> GetUser();
}