namespace LOGIK;
public class MessageService
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
    public void MakeMessage(Message message)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        _messageSender.SendMessage( message, newMessageId);
    }
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _conversationHandler.GetAllMessagesOverlookTest(user);
        return messages;
    }
    public List<Message> ShowOneMessageConversation(int messageId, int fromUserId, int thisUserId)
    {
        // den hittar meddelande med specifikt id
        List<Message>messages = _conversationHandler.GetMessageConversationTEST(messageId, fromUserId, thisUserId );
        return messages;
    }

}