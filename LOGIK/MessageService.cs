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
    public List<Message> ShowAllMessages(User user)
    {
        return allMessages = _messageHandeler.SeeMyMessages(user);
    }
    public void ShowOneMessage(int messageId)
    {
        // den hittar meddelande med specifikt id
        message = _messageHandeler.GetMessage(messageId);
        Console.WriteLine(message.ToString());
    }

}