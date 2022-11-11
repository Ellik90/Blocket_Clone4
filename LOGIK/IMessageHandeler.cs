namespace LOGIK;
public interface IMessageHandeler
{
    public int CreateMessage(Message message);
    public void SendMessage(Message message, int messageId);
    public List<Message> GetAllMessagesOverlook(User user);
    public List<Message> GetMessageConversation(int messageId);
    public void DeleteMessage(int messageId);
    
}