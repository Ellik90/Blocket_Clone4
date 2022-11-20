using TYPES;
using DATABASE;

namespace LOGIK;
public class AdminMessageService : IAdminMessageService
{
    IAdminMessageHandler _adminMessager;
    IMessageSender _messageSender;
    public AdminMessageService(IAdminMessageHandler adminMessager, IMessageSender messageSender)
    {
        _adminMessager = adminMessager;
        _messageSender = messageSender;
    }
    public int GetSender(int messageId)
    {
        return _adminMessager.AdminGetSenderId(messageId);
    }
    public List<Message> GetUsersMessages(Admin admin)
    {
        return _adminMessager.GetUsersMessages(admin);
    }
    public void MessageUser(Message message, int messageId)
    {
        _adminMessager.CreateMessage(message, messageId);
    }
}