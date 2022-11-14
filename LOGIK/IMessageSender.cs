namespace LOGIK;
public interface IMessageSender
{
    public int CreateMessage(Message message);
    public int SendMessage(Message message, int messageId);
    public int AddConversationThread(int fromUserId, int userMessageId);
    public int GetSenderId(int messageId);

}