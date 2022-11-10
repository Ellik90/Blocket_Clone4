namespace LOGIK;
public interface IMessageHandeler
{
    public int CreateMessage(Message message);
    public void SendMessage(int messageId, Message message);
    public List<Message> GetAllMessagesOverlook(User user);
    public Message GetMessage(int messageId);
    public void DeleteMessage(int messageId);
    
}