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
        _messageHandeler.SendMessage(newMessageId, message);
    }
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _messageHandeler.GetAllMessagesOverlook(user);
        return messages;
    }
    public Message ShowOneMessage(int messageId)
    {
        // den hittar meddelande med specifikt id
        message = _messageHandeler.GetMessage(messageId);
        return message;
    }

}