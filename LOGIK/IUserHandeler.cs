namespace LOGIK;
public interface IUserHandeler
{
    public int NicknameExists(string nickname);
    public int CreateUser(User user);
    public int UserLogInExists(User user);  // tex IVerifyUserManager ? för dessa
    public int UserEmailExists(string email);
    public int DeleteUser(User user);  
    public int GetUserIdFromAdvertise(int advertiseId);
    public List<User> GetUser();
}