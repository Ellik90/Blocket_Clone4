namespace LOGIK;
public interface IMessageService
{
    public void MakeMessage(Message message, User user);
    public List<Message> ShowAllMessages(User user);
    public List<Message> ShowOneMessageConversation(int messageId, int participantId, int myId);
    public List<Message> ShowStructuredConversation(int messageId, int fromUserId, int thisUserId);
    public void DeleteConversation(int myid, int participantId);
    
}