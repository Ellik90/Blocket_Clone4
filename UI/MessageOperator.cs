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
        int participantId = _messageSender.GetSenderId(messageId);
        return participantId;
    }


}