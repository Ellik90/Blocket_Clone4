using Dapper;
using MySqlConnector;
using TYPES;
namespace DATABASE;
// message borde ha from_user_id, så sender alltid är med i meddelandet som skapas direkt.
// conversation table borde finnas med
// table som håller konversationen, och ett table som håller vilka som har konversationen. 
// på så sätt kan en användare radera konversationen utan att det påverkar den andra
// som det är nu, om en användare raderar konve. så raderas det för alla!! OBS ANGELINA FIXA DET 
public class MessageDB : IMessageSender, IConversationHandler
{
    public MessageDB() { }
    public int GetSenderId(int messageId)
    {
        int fromUserId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT from_user_id FROM user_message where message_id = @messageid;";
            fromUserId = connection.QuerySingle<int>(query, new { @messageid = messageId });
        }
        return fromUserId;
    }
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
    public int SendMessage(Message message, int messageId) // int MessageId om create message hämtar medd ID
    {
        int usermessageId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_message (from_user_id, to_user_id, message_id) VALUES(@IDFromUser, @IDToUser, @ID); SELECT LAST_INSERT_ID();";
            usermessageId = connection.ExecuteScalar<int>(query, new { @IDFromUser = message.IDFromUser, @IDToUser = message.IDToUser, @ID = messageId });
            //@fromuser = message.IDFromUser, @touser = message.IDToUser, @messageid = messageId 
        }
        return usermessageId;
    }
    public int AddConversationThread(int userId, int userMessageId)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO conversation_thread (user_id, user_message_id) VALUES(@Id, @usermessageId);";
            rows = connection.ExecuteScalar<int>(query, new { @Id = userId, @usermessageId = userMessageId });
        }
        return rows;
    }
    public int DeleteMessageConversation(int myId, int participantId)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = " DELETE ct FROM conversation_thread ct " +
            "INNER JOIN user_message um  ON (um.id = ct.user_message_id) " +
            "INNER JOIN users u1 ON (u1.id = um.from_user_id) " +
            "INNER JOIN users u2 ON (u2.id = um.to_user_id) " +
            "WHERE (u1.id = @participantid AND u2.id = @myid) " +
            "OR (u2.id = @participantid AND u1.id = @myid) " +
            "AND ct.user_id = @myid;";
            rows = connection.ExecuteScalar<int>(query, new { @myid = myId, @participantId = participantId });
        }
        return rows;
    }
    public List<Message> GetMessagesNew(User user)
    {
        List<Message> allMessages = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT p.id, p.rubric, u1.nick_name as 'namefromuser',u2.nick_name as 'touser',  COUNT(um.from_user_id) as 'countMessagesFromUser' " +
            "FROM user_message um " +
            " INNER JOIN message p ON um.message_id = p.id " +
            " INNER JOIN conversation_thread ct ON (ct.user_message_id = um.id) " +
            "LEFT JOIN users u1 ON um.from_user_id = u1.id " +
            "LEFT JOIN users u2 ON um.to_user_id = u2.id " +
            "WHERE u2.id = @id AND ct.user_id = @id " +
            "GROUP BY um.from_user_id " +
            "HAVING COUNT(from_user_id) >= 1 " +
            "ORDER BY um.date_sent ASC;";
            // " INNER JOIN message p ON um.message_id = p.id " +
            // "LEFT JOIN users u1 ON um.from_user_id = u1.id " +
            // "LEFT JOIN users u2 ON um.to_user_id = u2.id " +
            // "LEFT JOIN conversation_thread ct ON ct.user_id = u2.id " +
            // "WHERE u2.id = @id GROUP BY um.from_user_id " +
            // "HAVING COUNT(from_user_id) >= 1 " +
            // "ORDER BY um.date_sent ASC;";
            allMessages = connection.Query<Message>(query, param: user).ToList();
        }
        return allMessages;
    }

    public List<Message> GetMessageConversationNew(int messageId, int participantId, int myId)
    {
        List<Message> messages = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT p.rubric, p.content, u1.nick_name as 'namefromuser' " +
            " FROM user_message um  " +
            "LEFT JOIN message p ON (um.message_id = p.id) LEFT JOIN users u1 ON (u1.id = um.from_user_id) " +
            " LEFT JOIN users u2 ON (u2.id = um.to_user_id) LEFT JOIN conversation_thread ct ON (ct.user_id = u1.id) " +
            "  WHERE (u1.id = @participantid AND u2.id = @myid) OR (u2.id = @participantid AND u1.id = @myid) AND ct.user_id = @myid GROUP BY ct.user_id ORDER BY um.date_sent ASC;";
            messages = connection.Query<Message>(query, new { @messageid = messageId, @otheruserid = participantId, @myid = myId }).ToList();
        }
        return messages;
    }


}