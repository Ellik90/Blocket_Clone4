using TYPES;
namespace DATABASE;

public interface IAdminMessageHandler
{
    public int CreateMessage(Message message, int repliedMessageId);
    public int AdminGetSenderId(int messageId);
    public List<Message> GetUsersMessages(Admin admin);
}