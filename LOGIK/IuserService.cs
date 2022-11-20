using TYPES;
using DATABASE;
namespace LOGIK;
public interface IUserService
{
    public User GetTheUser(User user);
    public bool GetUserIdToAD(int advertiseId);
    public bool MakeUser(User user);
    public bool CheckNickNameExists(string nickName);
    public bool CheckUserEmailExists(string email);
    public bool DeleteTheUser(User user);
    public bool DescriptionInput(User user, string updateDescription);
    public bool UpdateEmail(User user, string userEmail);
    public bool UpdateNickname(User user, string updateNickname);
    public bool UpDateDescription(User user, string updateDescription);
     public bool UpDatePassword(User user, string passWord);
}