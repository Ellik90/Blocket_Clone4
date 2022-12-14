using TYPES;
namespace LOGIK;
public interface IMessageService
{
    // public bool MakeMessage(Message message, User user);
    public List<Message> ShowAllMessages(User user);
    public List<Message> ShowOneMessageConversation(int messageId, int participantId, int myId);
    public List<Message> ShowStructuredConversation(int messageId, int fromUserId, int thisUserId);
    public void DeleteConversation(int myid, int participantId);
    public int GetSender(int messageId);
    public bool MessageToAdmin(User user, Message message);
    // public List<Message> GetUsersMessages(Admin admin);
    // public void MessageAdminToUser(Admin admin, Message message, int senderId, int messageId);
    //  public int AdminGetSender(int messageId);
     public List<Message> GetMessagesFromAdmin(User user);
     public bool MakeMessage(Message message);
    
    
}