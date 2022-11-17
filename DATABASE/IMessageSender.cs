using TYPES;
namespace DATABASE;
public interface IMessageSender
{
    public int CreateMessage(Message message);
    public int SendMessage(Message message, int messageId);
    public int AddConversationThread(int fromUserId, int userMessageId);
    public int GetSenderId(int messageId);
    public List<int> GetAdminId();
    public int SendMessageToAdmin(int userId, Message message, List<int> adminIds);

}