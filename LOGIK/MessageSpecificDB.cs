using Dapper;
using MySqlConnector;
namespace LOGIK;

// denna bestämmer inte lika hårt hur utkommet ska vara strukturerat 

public class MessageSpecificDB : IMessageSender, IConversationHandler
{
    public int CreateMessage(Message message)
    {
        throw new NotImplementedException();
    }
    public void SendMessage(Message message, int messageId)
    {
        throw new NotImplementedException();
    }

    public void DeleteMessageConversation(int messageId)
    {
        throw new NotImplementedException();
    }

    public List<Message> GetMessageConversationTEST(int messageId, int otherUserId, int myId)
    {
        throw new NotImplementedException();
    }

    public List<Message> GetAllMessagesOverlookTest(User user)
    {
        List<Message> allMessages = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT p.id, p.rubric, u1.nick_name as 'namefromuser',COUNT(um.from_user_id) as 'countMessagesFromUser' " +
            "FROM user_message um INNER JOIN message p ON um.message_id = p.id INNER JOIN users u1 ON um.from_user_id = u1.id " +
            "INNER JOIN users u2 ON um.to_user_id = u2.id WHERE u2.id = @id;";
            allMessages = connection.Query<Message>(query, param: user).ToList();
        }
        return allMessages;
    }

    int IMessageSender.AddConversationThread(User user, int messageId)
    {
        throw new NotImplementedException();
    }
}