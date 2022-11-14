using LOGIK;
class MessageOperator
{
    IMessageService _messageService;
    IMessageSender _messageSender;
    public MessageOperator(IMessageService messageService, IMessageSender messageSender)
    {
        _messageService = messageService;
        _messageSender = messageSender;
    }
    public void WriteMessageToAd(int adUserId, User user)
    {
        // // 3. SKRIV MEDDELANDE TILL ANNONSENS ANVÄNDARE
        string rubric = ConsoleInput.GetString("Rubric: ");
        string content = ConsoleInput.GetString("Content: ");
        int idToUser = adUserId;
        Message answerMessage = new(rubric, content, user.Id, idToUser);
        _messageService.MakeMessage(answerMessage, user);
    }

    public void ShowAllMessages(User user)
    {
        user.messages = _messageService.ShowAllMessages(user);  //  DENNA FUNKAR MED LÅNG QUERY
        if (user.messages.Count() == 0)
        {
            Console.WriteLine("No Messages");
        }
        foreach (Message item in user.messages)
        {
            Console.WriteLine($"{item.MessagesToString()}");
        }
    }

    public int GetSender(int messageId)
    {
        int participantId = _messageService.GetSender(messageId);
        return participantId;
    }

    public void ShowMessageConversation(int messageId, int participantId, User user)
    {
        List<Message> messages = _messageService.ShowOneMessageConversation(messageId, participantId, user.Id);
        foreach (Message item in messages)
        {
            Console.WriteLine($"{item.nameFromUser}\n\r{item.Rubric}\n\r{item.Content}\n\r");
        }
    }

    public void ReplyToMessage(int idToUser, User user)
    {
        string rubric = ConsoleInput.GetString("Rubric: ");
        string content = ConsoleInput.GetString("Content: ");
        Message replyMessage = new(rubric, content, user.Id, idToUser);
        _messageService.MakeMessage(replyMessage, user);
    }

    public void DeleteConversation(User user, int participantId)
    {
        _messageService.DeleteConversation(user.Id, participantId);
    }

}