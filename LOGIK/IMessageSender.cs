namespace LOGIK;
public interface IMessageSender
{
    public int CreateMessage(Message message);
    public void SendMessage(Message message, int messageId);
}