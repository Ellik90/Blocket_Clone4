using TYPES;
using DATABASE;
namespace LOGIK;
public class MessageService : IMessageService
{
    IMessageSender _messageSender;
    IConversationHandler _conversationHandler;
    IAdminMessager _adminMessager;
    List<Message> allMessages = new();
    List<Message> oneConversationMessages = new();
    Message message = new();
    public MessageService(IMessageSender messageSender, IConversationHandler conversationHandler, IAdminMessager adminMessager)
    {
        _messageSender = messageSender;
        _conversationHandler = conversationHandler;
        _adminMessager = adminMessager;
    }
    public bool MakeMessage(Message message, User user)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        int usermessageId = _messageSender.SendMessage(message, newMessageId);
        int rows = _messageSender.AddConversationThread(user.Id, usermessageId);
        int toUserId = message.IDToUser;
        int converstaionRows = _messageSender.AddConversationThread(toUserId, usermessageId);
        if (newMessageId > 0 && usermessageId > 0 && rows > 0 && converstaionRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _conversationHandler.GetMessagesNew(user); //_conversationHandler.GetAllMessagesOverlookTest(user);
        return messages;
    }
    public List<Message> ShowOneMessageConversation(int messageId, int participantId, int myId)
    {
        // den hittar meddelande med specifikt id
        List<Message> messages = _conversationHandler.GetMessageConversationTEST(messageId, participantId, myId);//_conversationHandler.GetMessageConversationTEST(messageId, fromUserId, thisUserId);
        return messages;
    }
    public List<Message> ShowStructuredConversation(int messageId, int fromUserId, int thisUserId)
    {
        // DENNA SKA INNEHÅLLA FUNKTION, TAR IN ALLA MEDDELANDEN OCH STRUKTURERAR KONVERSATION HÄR I?
        List<Message> messages = _conversationHandler.GetMessageConversationTEST(messageId, fromUserId, thisUserId);
        return messages;
    }
    public void DeleteConversation(int myid, int participantId)
    {
        _conversationHandler.DeleteMessageConversation(myid, participantId);
    }

    public int GetSender(int messageId)
    {
        return _messageSender.GetSenderId(messageId);
    }
     public int AdminGetSender(int messageId)
    {
        return _adminMessager.AdminGetSenderId(messageId);
    }

    public bool MessageToAdmin(User user, Message message)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        List<int>adminIds = _messageSender.GetAdminId();
        int rows = _messageSender.SendMessageToAdmin(user.Id, message, adminIds);
        if(rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     public void MessageAdminToUser(Admin admin, Message message, int senderId, int messageId)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        allMessages.Add(message);
        int replyId = _adminMessager.SendMessageFromAdmin(senderId, admin.Id, newMessageId);
        _adminMessager.UpdateMessageIsReplied(messageId);
    }
    public List<Message> GetUsersMessages(Admin admin)
    {
        return _adminMessager.GetUsersMessages(admin);
    }
    public List<Message> GetMessagesFromAdmin(User user)
    {
        List<Message> getMessages = _conversationHandler.GetMessagesFromAdmin(user);
        List<Message> messagesNotOld = new();
        foreach(Message item in messagesNotOld)
        {
            if(DateTime.Now.AddDays(7) < item.DateSent)
            {
                messagesNotOld.Add(item);
            }
        }
        return messagesNotOld;

    }
}