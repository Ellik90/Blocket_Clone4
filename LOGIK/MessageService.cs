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
    public void MakeMessage(Message message, User user)
    {
        int newMessageId = _messageSender.CreateMessage(message);
        message.ID = newMessageId;
        allMessages.Add(message);
        int usermessageId = _messageSender.SendMessage(message, newMessageId);
        int rows = _messageSender.AddConversationThread(user.Id, usermessageId);
        int toUserId = message.IDToUser;
        rows = _messageSender.AddConversationThread(toUserId, usermessageId);
        if(rows > 0)
        {
            Console.WriteLine("Skickat");
        }
    }
    // denna mindre funktion interface
    public List<Message> ShowAllMessages(User user)
    {
        List<Message> messages = _conversationHandler.GetMessagesNew(user); //_conversationHandler.GetAllMessagesOverlookTest(user);
        //_conversationHandler.GetMessagesNew(user); 
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