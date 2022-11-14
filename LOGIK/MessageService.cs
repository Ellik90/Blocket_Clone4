namespace LOGIK;
public class MessageService : IUIMessageHandler
{
    //här i är funktionerna mellan användaren och db, tex makemessage(strin rubric, string content) osv..
    IMessageHandeler _messageHandeler;
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
    public void MakeMessage(Message message, User user)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        int usermessageId = _messageSender.SendMessage(message, newMessageId);
        int rows = _messageSender.AddConversationThread(user.Id, usermessageId);
        int toUserId = message.IDToUser;
        _messageSender.AddConversationThread(toUserId, usermessageId);
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

}