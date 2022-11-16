using TYPES;
using DATABASE;
namespace LOGIK;
public interface IuserService
{
    public User GetTheUser(User user);
    public bool GetUserIdToAD(int advertiseId);
    public bool MakeUser(User user);
    public bool CheckNickNameExists(string nickName);
    public bool DeleteTheUser(User user);
    public bool DescriptionInput(User user, string updateDescription);
}