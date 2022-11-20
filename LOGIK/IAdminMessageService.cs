using TYPES;
namespace LOGIK;
public interface IAdminMessageService
{
    public List<Message> GetUsersMessages(Admin admin);
    public void MessageUser(Message message, int messageId);
    public int GetSender(int messageId);
}