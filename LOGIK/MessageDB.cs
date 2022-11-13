using Dapper;
using MySqlConnector;
namespace LOGIK;
// message borde ha from_user_id, så sender alltid är med i meddelandet som skapas direkt.
// conversation table borde finnas med
// table som håller konversationen, och ett table som håller vilka som har konversationen. 
// på så sätt kan en användare radera konversationen utan att det påverkar den andra
// som det är nu, om en användare raderar konve. så raderas det för alla!! OBS ANGELINA FIXA DET 
public class MessageDB : IMessageSender, IConversationHandler
{
    public MessageDB() { }
    // public List<Message> GetAllMessagesOverlook(User user)
    // {
    //     List<Message> messagesOverlooks = new();
    //     using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
    //     {
    //         string query = "SELECT message.id, message.rubric, users.nick_name as 'namefromuser' FROM message INNER JOIN user_message ON user_message.message_id = message.id INNER JOIN users ON user_message.from_user_id = users.id WHERE user_message.to_user_id = @Id;";
    //         messagesOverlooks = connection.Query<Message>(query, param: user).ToList();
    //     }
    //     return messagesOverlooks;
    // }

    public List<Message> GetAllMessagesOverlookTest(User user)
    {
        List<Message> messagesOverlooks = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT p.id, p.rubric, u1.nick_name as 'namefromuser',u2.nick_name as 'touser',  COUNT(um.from_user_id) as 'countMessagesFromUser'" +
            "FROM user_message um INNER JOIN message p ON um.message_id = p.id LEFT JOIN users u1 ON um.from_user_id = u1.id " +
            "LEFT JOIN users u2 ON um.to_user_id = u2.id WHERE u2.id = @id GROUP BY um.from_user_id HAVING COUNT(from_user_id) >= 1 ORDER BY um.date_sent ASC;";
            messagesOverlooks = connection.Query<Message>(query, param: user).ToList();   //      OR (u1.id = @Id) 
            // SELECT p.id, p.rubric, u1.nick_name as 'namefromuser', "+
            // "COUNT(um.from_user_id) as 'countmessagesfromuser' FROM user_message um INNER JOIN message p ON um.message_id = p.id "+
            // "INNER JOIN users u1 ON um.from_user_id = u1.id INNER JOIN users u2 ON um.to_user_id = u2.id WHERE (u2.id = @Id) ORDER BY COUNT(um.from_user_id) DESC;";
        }
        return messagesOverlooks;
    }

    public List<Message> GetMessages(User user)
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
    public int GetSenderId(int messageId)
    {
        // här
        int fromUserId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT from_user_id FROM user_message where message_id = @messageid;";
            fromUserId = connection.QuerySingle<int>(query, new { @messageid = messageId });
        }
        return fromUserId;
    }
    // public List<Message> GetMessageConversation(int messageId)
    // {
    //     List<Message> messages = new();
    //     using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
    //     {
    //         string query = "SELECT message.rubric, message.content, users.nick_name as 'namefromuser', from_user_id as 'idfromuser' FROM message INNER JOIN user_message ON user_message.message_id = message_id INNER JOIN users ON users.id = user_message.from_user_id WHERE message.id = @messageid;";
    //         messages = connection.Query<Message>(query, new { @messageid = messageId }).ToList();
    //     }
    //     return messages;
    // }

    public List<Message> GetMessageConversationTEST(int messageId, int otherUserId, int myId)
    {
        List<Message> messages = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT p.rubric, p.content, u1.nick_name as 'namefromuser' " +
            " FROM user_message um LEFT JOIN message p ON (um.message_id = p.id) LEFT JOIN users u1 " +
            " ON (u1.id = um.from_user_id) LEFT JOIN users u2 ON (u2.id = um.to_user_id) " +
            "  WHERE (u2.id = @otheruserid AND u1.id = @myid) OR (u2.id = @myid AND u1.id = @otheruserid) ORDER BY um.date_sent ASC;";
            messages = connection.Query<Message>(query, new { @messageid = messageId, @otheruserid = otherUserId, @myid = myId }).ToList();
        }
        return messages;
    }
    public void DeleteMessage(int messageId)
    {
        throw new NotImplementedException();
    }

    public int CreateMessage(Message message)
    {
        int messageId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO message (rubric, content) VALUES(@rubric, @content);SELECT LAST_INSERT_ID();";
            messageId = connection.ExecuteScalar<int>(query, param: message);
        }
        return messageId;
    }
    public void SendMessage(Message message, int messageId) // int MessageId om create message hämtar medd ID
    {
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_message (from_user_id, to_user_id, message_id) VALUES(@IDFromUser, @IDToUser, @ID);";
            int rows = connection.ExecuteScalar<int>(query, new { @IDFromUser = message.IDFromUser, @IDToUser = message.IDToUser, @ID = messageId });
            //@fromuser = message.IDFromUser, @touser = message.IDToUser, @messageid = messageId 
        }
    }

    public int AddConversationThread(User user, int messageId)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO conversation_thread (user_id, message_id) VALUES(@Id, @messageId);";
            rows = connection.ExecuteScalar<int>(query, new { @Id = user.Id, @messageId = messageId});
        }
        return rows;
    }

    public void DeleteMessageConversation(int messageId)
    {

    }
}