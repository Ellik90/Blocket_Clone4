using TYPES;
using DATABASE;
namespace LOGIK;
public class MessageService : IMessageService
{
    IMessageSender _messageSender;
    IConversationHandler _conversationHandler;
    IAdminMessageHandler _adminMessager;
    List<Message> allMessages = new();
    List<Message> oneConversationMessages = new();
    Message message = new();
    public MessageService(IMessageSender messageSender, IConversationHandler conversationHandler, IAdminMessageHandler adminMessager)
    {
        _messageSender = messageSender;
        _conversationHandler = conversationHandler;
        _adminMessager = adminMessager;
    }
    public bool MakeMessage(Message message)
    {
        int rows = _messageSender.CreateMessageTest(message);
        if(rows > 0)
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
    public List<Message> GetMessagesFromAdmin(User user)
    {
        List<Message> getMessages = _conversationHandler.GetMessagesFromAdmin(user);
        List<Message> messagesNotOld = new();
        foreach(Message item in getMessages)
        {
            if(DateTime.Now < item.DateSent.AddDays(7))
            {
                messagesNotOld.Add(item);
            }
        }
        return messagesNotOld;
    }
}