using TYPES;
namespace DATABASE;
public interface IUserEditor 
{
    public int UpdateEmail(User user, string userEmail);
    public int UpdateNickName(User user, string nickname);
    public int UpDateDescription(User user, string updateDescription);
    //hej
}