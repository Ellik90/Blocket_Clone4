using TYPES;
using DATABASE;

namespace LOGIK;
public class AdminMessageService : IAdminMessageService
{
    IAdminMessager _adminMessager;
    IMessageSender _messageSender;
    public AdminMessageService(IAdminMessager adminMessager, IMessageSender messageSender)
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
        // int newMessageId = _messageSender.CreateMessage(message);
        // int replyId = _adminMessager.SendMessageFromAdmin(senderId, admin.Id, newMessageId);
        // _adminMessager.UpdateMessageIsReplied(messageId);
    }
}