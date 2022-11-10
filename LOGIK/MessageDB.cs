using Dapper;
using MySqlConnector;
namespace LOGIK;
public class MessageDB : IMessageHandeler
{
    public List<Message> GetAllMessagesOverlook(User user)
    {
        List<Message>messagesOverlooks = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT message.id, message.rubric, users.nick_name as 'idfromuser' FROM message INNER JOIN user_message ON user_message.message_id = message.id INNER JOIN users ON user_message.from_user_id = users.id WHERE user_message.to_user_id = @Id;";
            messagesOverlooks = connection.Query<Message>(query, param:user).ToList();
        }
        return messagesOverlooks;
    }
    public IEnumerable<Message> SeeMyMessagesAsIenumerable(User user)
    {
        throw new NotImplementedException();
    }

    public Message GetMessage(int messageId)
    {
        Message message = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT message.rubric, message.content, users.nick_name as 'idfromuser' FROM message INNER JOIN user_message ON user_message.message_id = message_id INNER JOIN users ON users.id = user_message.from_user_id WHERE message.id = @messageid;";
            message = connection.QuerySingle<Message>(query, new{@messageid = messageId});
        }
        return message;
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
    public void SendMessage(int messageId, Message message)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_message (from_user_id, to_user_id, message_id) VALUES(@fromuser, @touser, @messageid);";
            messageId = connection.ExecuteScalar<int>(query, new { @fromuser = message.IDFromUser, @touser = message.IDToUser, @messageid = messageId });
        }
    }
}