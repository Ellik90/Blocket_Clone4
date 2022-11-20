using TYPES;
namespace DATABASE;
public interface IUserHandeler
{
    public int CreateUser(User user);
    public int DeleteUser(User user);  
    public int GetUserIdFromAdvertise(int advertiseId);
    public List<User> GetUser();
}