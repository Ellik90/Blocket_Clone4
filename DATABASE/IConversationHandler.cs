using TYPES;
namespace DATABASE;
public interface IConversationHandler
{
    //public List<Message> GetAllMessagesOverlookTest(User user);
    //public List<Message> GetMessages(User user);
    public List<Message> GetMessageConversation(int messageId, int otherUserId, int myId);
    //public bool DeleteMessageConversation(int messageId, int otherUserId, int myId); // från bara en user
    public int DeleteMessageConversation(int myId, int userMessageId);
    public List<Message> GetMessagesOverview(User user);
    // public List<Message> GetMessageConversationNew(int messageId, int participantId, int myId);
    // // public List<Message> GetUsersMessages(Admin admin);
    public List<Message> GetMessagesFromAdmin(User user);

}