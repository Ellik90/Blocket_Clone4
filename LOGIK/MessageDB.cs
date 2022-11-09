using Dapper;
using MySqlConnector;
namespace LOGIK;
public class MessageDB : IMessageHandeler
{
    public List<Message> SeeMyMessages(User user)
    {
        using(MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
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

    public Message ShowOneMessage(int messageId)
    {
        throw new NotImplementedException();
    }

    public void DeleteMessage(Message message, User thisUser)
    {
        throw new NotImplementedException();
    }

    public void MakeMessage(Message message, User fromUser, User toUser)
    {
        int messageId = 0;
        using(MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "INSERT INTO message (rubric, content) VALUES(@rubric, @content);SELECT LAST_INSERT_ID();";
            messageId = connection.ExecuteScalar<int>(query, param: message);
        }      
    }
    public void SendMessage(int messageId, User fromUser, int toUserId)
    {
        using(MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=Mabedamo140065;"))
        {
            string query = "INSERT INTO user_message (from_user_id, to_user_id, message_id) VALUES(@fromuser, @touser, @message);";
            messageId = connection.ExecuteScalar<int>(query, new{ @fromuser = fromUser.Id, @touser = toUserId, @id = messageId });
        }      
    }
    void SetMessageToOld(List<Message>messages)
    {
        foreach(Message item in messages)
        {
            if(item.IsMessageOld() == true)
            {
                //uppdatera isold till databas 
            }
        }
    }
}