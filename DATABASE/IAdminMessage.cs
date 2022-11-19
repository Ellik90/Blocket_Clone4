using TYPES;
namespace DATABASE;

public interface IAdminMessager
{
    public int CreateMessage(Message message, int repliedMessageId);
    public int AdminGetSenderId(int messageId);
    public int SendMessageFromAdmin(int userId, int adminId, int messageId);
    public List<Message> GetUsersMessages(Admin admin);
    public void UpdateMessageIsReplied(int messageId);

}