using LOGIK;
using TYPES;
class MessageOperator
{
    IMessageService _messageService;
    public MessageOperator(IMessageService messageService)
    {
        _messageService = messageService;
    }
    // public void WriteMessageToAd(int adUserId, User user)
    // {
    //     // // 3. SKRIV MEDDELANDE TILL ANNONSENS ANVÄNDARE
    //     string rubric = ConsoleInput.GetString("Rubric: ");
    //     string content = ConsoleInput.GetString("Content: ");
    //     int idToUser = adUserId;
    //     try
    //     {
    //         Message answerMessage = new(rubric, content, user.Id, idToUser);
    //         _messageService.MakeMessageTest(answerMessage);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    // }
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
    // public int AdminGetSender(int messageId)
    // {
    //     int participantId = 0;
    //     try
    //     {
    //         participantId = _messageService.AdminGetSender(messageId);
    //         if (participantId == 0)
    //         {
    //             throw new ArgumentNullException();
    //         }
    //     }
    //     catch (ArgumentNullException)
    //     {
    //         Console.WriteLine("Can't find sender to make reply.");
    //     }
    //     return participantId;
    // }
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
    public void SendMessage(int idToUser, User user, string reciever) // skickar meddelande till ad, samt svara på meddel.
    {
        string rubric = ConsoleInput.GetString("Rubric: ");
        string content = ConsoleInput.GetString("Content: ");
        Message newMessage = new(rubric, content, user.Id, idToUser);
        if (reciever == "user")
        {
            try
            {
                _messageService.MakeMessage(newMessage);
                Console.WriteLine("Message sent!");
            }
            catch(Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }
        else if (reciever == "admin")
        {
            try
            {
                _messageService.MessageToAdmin(user, newMessage);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
    public void DeleteConversation(User user, int participantId)
    {
        _messageService.DeleteConversation(user.Id, participantId);
    }

    // public void WriteMessageToAdmin(User user)
    // {
    //     string rubric = ConsoleInput.GetString("Rubric: ");
    //     string content = ConsoleInput.GetString("Content: ");
    //     int idToUser = 0;
    //     try
    //     {
    //         Message newMessage = new(rubric, content, user.Id, idToUser);
    //         _messageService.MessageToAdmin(user, newMessage);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    // }
    // public void AdminMakeMessage(Admin admin, int userId, int messageId)
    // {
    //     string rubric = ConsoleInput.GetString("Rubric: ");
    //     string content = ConsoleInput.GetString("Content: ");
    //     int idToUser = 0;
    //     try
    //     {
    //         Message newMessage = new(rubric, content, userId, idToUser);
    //         _messageService.MessageAdminToUser(admin, newMessage, userId, messageId);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    // }

    // public void ShowUsersUnreadMessages(Admin admin)
    // {
    //     List<Message> messages = _messageService.GetUsersMessages(admin);
    //     foreach (Message item in messages)
    //     {
    //         Console.WriteLine(item.AdminMessageString());
    //     }
    // }
    public void ShowMessagesFromAdmin(User user)
    {
        List<Message> messages = _messageService.GetMessagesFromAdmin(user);
        foreach (Message item in messages)
        {
            Console.WriteLine(item.ConversationToString());
        }
    }
}