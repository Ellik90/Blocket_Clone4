using TYPES;
namespace DATABASE;

public interface IAdminMessager
{
    public int AdminGetSenderId(int messageId);
    public List<int> GetAdminId();
    public int SendMessageUserAdmin(int userId, Message message, List<int> adminIds);
    public List<Message> GetMessagesFromAdmin(User user);
    public int SendMessageFromAdmin(int userId, int adminId, int messageId);

}