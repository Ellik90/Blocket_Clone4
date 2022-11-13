namespace LOGIK;
public interface IConversationHandler
{
    public List<Message> GetAllMessagesOverlookTest(User user);
    //public List<Message> GetMessages(User user);
    public List<Message> GetMessageConversationTEST(int messageId, int otherUserId, int myId);
    //public bool DeleteMessageConversation(int messageId, int otherUserId, int myId); // från bara en user
    public void DeleteMessageConversation(int messageId);

}