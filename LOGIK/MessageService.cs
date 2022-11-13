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
        _messageSender.SendMessage(message, newMessageId);
    }
    // denna mindre funktion interface
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _conversationHandler.GetAllMessagesOverlookTest(user);
        return messages;
    }

    // denna nedanför behöver vara i annan interface, då den är mer funktion
    public List<Message> ShowMessagesOverlook(User user)
    {
        allMessages = _conversationHandler.GetAllMessagesOverlookTest(user);
        List<Message> listMessagePerSender = new();

        foreach (Message item in allMessages)
        {
            if (!listMessagePerSender.Contains(item))
            {
                listMessagePerSender.Add(item);
            }
        }



        return listMessagePerSender;


    }
    // denna i interface med mindre funktion, med mer bestämd db?
    public List<Message> ShowOneMessageConversation(int messageId, int fromUserId, int thisUserId)
    {
        // den hittar meddelande med specifikt id
        List<Message> messages = _conversationHandler.GetMessageConversationTEST(messageId, fromUserId, thisUserId);
        return messages;
    }

    public List<Message> ShowStructuredConversation(int messageId, int fromUserId, int thisUserId)
    {
        // DENNA SKA INNEHÅLLA FUNKTION, TAR IN ALLA MEDDELANDEN OCH STRUKTURERAR KONVERSATION HÄR I?
        List<Message> messages = _conversationHandler.GetMessageConversationTEST(messageId, fromUserId, thisUserId);
        return messages;
    }

}