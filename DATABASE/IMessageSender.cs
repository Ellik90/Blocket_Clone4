using TYPES;
namespace DATABASE;
public interface IMessageSender
{
    public int CreateMessage(Message message);
    // // public int SendMessage(Message message, int messageId);
    // // public int AddConversationThread(int fromUserId, int userMessageId);
    public int CreateMessageTest(Message message);
    public int GetSenderId(int messageId);
    // public int AdminGetSenderId(int messageId);
    // public List<int> GetAdminId();
    public int SendMessageToAdmin(int userId, Message message, List<int> adminIds);
    // public int SendMessageFromAdmin(int userId, int adminId, int messageId);
    public List<int> GetAdminId();
    // public void UpdateMessageIsReplied(int messageId);

}