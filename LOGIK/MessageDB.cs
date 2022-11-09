using Dapper;
using MySqlConnector;
namespace LOGIK;
public class MessageDB : IMessageHandeler
{
    public List<Message> SeeMyMessages(User user)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "SELECT message.rubric, message.";
            //  messageId = connection.ExecuteScalar<int>(query, param: message);
        }
        return new List<Message>();
    }
    public IEnumerable<Message> SeeMyMessagesAsIenumerable(User user)
    {
        throw new NotImplementedException();
    }

    public Message GetMessage(int messageId)
    {
        Message message = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "SELECT message.rubric, message.content, users.nick_name FROM message INNER JOIN user_message ON user_message.message_id = message_id INNER JOIN users ON users.id = user_message.from_user_id WHERE message.id = 1;";
            message = connection.QuerySingle<Message>(query, new{@messageid = messageId});
        }

        return message;
    }

    public void DeleteMessage(Message message, User thisUser)
    {
        throw new NotImplementedException();
    }

    public void MakeMessage(Message message, User fromUser, User toUser)
    {
        int messageId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "INSERT INTO message (rubric, content) VALUES(@rubric, @content);SELECT LAST_INSERT_ID();";
            messageId = connection.ExecuteScalar<int>(query, param: message);
        }
    }
    public void SendMessage(int messageId, User fromUser, int toUserId)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "INSERT INTO user_message (from_user_id, to_user_id, message_id) VALUES(@fromuser, @touser, @message);";
            messageId = connection.ExecuteScalar<int>(query, new { @fromuser = fromUser.Id, @touser = toUserId, @id = messageId });
        }
    }
    void SetMessageToOld(List<Message> messages)
    {
        foreach (Message item in messages)
        {
            if (item.IsMessageOld() == true)
            {
                //uppdatera isold till databas 
            }
        }
    }
}