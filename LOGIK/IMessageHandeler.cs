namespace LOGIK;
public interface IMessageHandeler
{
    public void SendMessage(int messageId, User fromUser, int toUserId);
    public List<Message> SeeMyMessages(User user);
    public IEnumerable<Message> SeeMyMessagesAsIenumerable (User user);
    public Message GetMessage(int messageId);

    public void DeleteMessage(Message message, User thisUser);
    
}