namespace LOGIK;
public class MessageService
{
    //här i är funktionerna mellan användaren och db, tex makemessage(strin rubric, string content) osv..
    IMessageHandeler _messageHandeler;
    List<Message> allMessages = new();
    Message message = new();
    public MessageService(IMessageHandeler messageHandeler)
    {
        _messageHandeler = messageHandeler;
    }
    public void MakeMessage(Message message)
    {
        int newMessageId = _messageHandeler.CreateMessage(message);
        _messageHandeler.SendMessage( message, newMessageId);
    }
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _messageHandeler.GetAllMessagesOverlookTest(user);
        return messages;
    }
    public List<Message> ShowOneMessageConversation(int messageId, int fromUserId, int thisUserId)
    {
        // den hittar meddelande med specifikt id
        List<Message>messages= new();
        messages = _messageHandeler.GetMessageConversationTEST(messageId, fromUserId, thisUserId );
        return messages;
    }

}