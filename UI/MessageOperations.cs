using LOGIK;
class MessageOperations
{
    IMessageService _messageService;
    public MessageOperations(IMessageService messageService)
    {
        _messageService = messageService;
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


}