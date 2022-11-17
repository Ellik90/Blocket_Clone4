using TYPES;
using DATABASE;
namespace LOGIK;
public class MessageService : IMessageService
{
    //här i är funktionerna mellan användaren och db, tex makemessage(strin rubric, string content) osv..
    IMessageSender _messageSender;
    IConversationHandler _conversationHandler;
    List<Message> allMessages = new();
    List<Message> oneConversationMessages = new();
    Message message = new();
    public MessageService(IMessageSender messageSender, IConversationHandler conversationHandler)
    {
        _messageSender = messageSender;
        _conversationHandler = conversationHandler;
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

    public bool MessageToAdmin(User user, Message message)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        List<int>adminIds = _messageSender.GetAdminId();
        int rows = _messageSender.SendMessageUserAdmin(user.Id, message, adminIds);
        if(rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     public void MessageAdminToUser(Admin admin, Message message, int senderId)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        allMessages.Add(message);
        int replyId = _messageSender.SendMessageFromAdmin(senderId, admin.Id, newMessageId);
        _messageSender.UpdateMessageIsReplied(replyId, admin);
    }
    public List<Message> GetUsersMessages(Admin admin)
    {
        return _conversationHandler.GetUsersMessages(admin);
    }
}