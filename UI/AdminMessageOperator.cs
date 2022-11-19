using LOGIK;
using TYPES;
public class AdminMessageOperator
{
    IAdminMessageService _adminMessageService;
    public AdminMessageOperator(IAdminMessageService adminMessageService)
    {
        _adminMessageService = adminMessageService;
    }

    public int AdminGetSender(int messageId)
    {
        int participantId = 0;
        try
        {
            participantId = _adminMessageService.GetSender(messageId);
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
    public void AdminMakeMessage(Admin admin, int userId, int messageId)
    {
        string rubric = ConsoleInput.GetString("Rubric: ");
        string content = ConsoleInput.GetString("Content: ");
        try
        {
            Message newMessage = new(rubric, content, admin.Id, userId);
            _adminMessageService.MessageUser(newMessage, messageId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void ShowUsersUnreadMessages(Admin admin)
    {
        List<Message> messages = _adminMessageService.GetUsersMessages(admin);
        foreach (Message item in messages)
        {
            Console.WriteLine(item.AdminMessageString());
        }
    }
}