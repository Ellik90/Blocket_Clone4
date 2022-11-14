using LOGIK;
class MessageOperations
{
    IMessageService _messageService;
    public MessageOperations(IMessageService messageService)
    {
        _messageService = messageService;
    }
}