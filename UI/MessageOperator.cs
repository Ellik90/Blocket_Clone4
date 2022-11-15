using LOGIK;
class MessageOperator
{
    IMessageService _messageService;
    public MessageOperator(IMessageService messageService)
    {
        _messageService = messageService;
    }
    public void WriteMessageToAd(int adUserId, User user)
    {
        // // 3. SKRIV MEDDELANDE TILL ANNONSENS ANVÄNDARE
        string rubric = ConsoleInput.GetString("Rubric: ");
        string content = ConsoleInput.GetString("Content: ");
        int idToUser = adUserId;
        try
        {
            Message answerMessage = new(rubric, content, user.Id, idToUser);
            _messageService.MakeMessage(answerMessage, user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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
        int participantId = 0;
        try
        {
            participantId = _messageService.GetSender(messageId);
            if (participantId == 0)
            {
                throw new ArgumentNullException();
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Can't find sender to make reply.");
        }
        return participantId;
    }
    public void ShowMessageConversation(int messageId, int participantId, User user)
    {
        try
        {
            List<Message> messages = _messageService.ShowOneMessageConversation(messageId, participantId, user.Id);
            foreach (Message item in messages)
            {
                Console.WriteLine($"{item.nameFromUser}\n\r{item.Rubric}\n\r{item.Content}\n\r");
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No conversation found.");
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