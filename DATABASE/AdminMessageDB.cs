using Dapper;
using MySqlConnector;
using TYPES;
namespace DATABASE;
public class AdminMessageDB : IAdminMessager
{
    //GÖR TRANSACTION MED MEDD FRÅN ADMIN OCKSÅ! SEDAN SAMT TILL ADMIN!!

    public int CreateMessage(Message message, int repliedMessageId)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;Allow User Variables=true;"))
        {
            string query = "START TRANSACTION;" +
           "INSERT INTO message (rubric, content) VALUES(@rubric, @content);" +
           "SET @message_id := LAST_INSERT_ID();" +
           "INSERT INTO admin_message (user_id, admin_id, message_id, isreplied) VALUES(@idtouser, @idfromuser, @message_id, true);" +
           "UPDATE admin_message SET isreplied = true WHERE message_id = @repliedMessageId;"+
           "COMMIT; SELECT LAST_INSERT_ID();";
            rows = connection.QuerySingle<int>(query, new{@rubric = message.Rubric, @content = message.Content, @idtouser = message.IDToUser, @idfromuser = message.IDFromUser, @repliedMessageId = repliedMessageId});
        }
        return rows;
    }
    public int AdminGetSenderId(int messageId)
    {
        int fromUserId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT user_id FROM admin_message where message_id = @messageid;";
            fromUserId = connection.QuerySingle<int>(query, new { @messageid = messageId });
        }
        return fromUserId;
    }
    public int SendMessageFromAdmin(int userId, int adminId, int messageId)
    {
        int newMessageId = 0;
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO admin_message (user_id, admin_id, message_id, isreplied) VALUES(@userId, @adminId, @messageId, true); SELECT LAST_INSERT_ID();";
            messageId = connection.ExecuteScalar<int>(query, new { @userId = userId, @adminId = adminId, @messageId = messageId });
        }
        return newMessageId;
    }
    public void UpdateMessageIsReplied(int messageId)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "UPDATE admin_message SET isreplied = true WHERE message_id = @messageid;";
            int rows = connection.ExecuteScalar<int>(query, new { @messageid = messageId });
        }
    }
    public List<Message> GetUsersMessages(Admin admin)
    {
        List<Message> usersMessages = new();
        using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT message_id as 'id', user_id, date_sent as 'date', rubric, content, nick_name as 'namefromuser' FROM admin_message " +
            "INNER JOIN message ON admin_message.message_id = message.id " +
            "INNER JOIN users ON admin_message.user_id = users.id WHERE isreplied = false;";
            usersMessages = connection.Query<Message>(query).ToList();
        }
        return usersMessages;
    }



}