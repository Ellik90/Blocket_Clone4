using TYPES;
namespace DATABASE;
public class AdminMessageDB : IAdminMessager
{
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

    
}