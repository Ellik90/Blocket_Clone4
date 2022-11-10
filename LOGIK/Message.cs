namespace LOGIK;
public class Message
{
    public int ID { get; set; }
    public int IDFromUser { get; set; }
    public string idfromuser{get;set;}
    public int IDToUser { get; set; }
    public string Rubric { get; private set; }
    public string Content { get; private set; }
    public readonly DateTime DateSent;
    // public annons annons;
    public User user = new();
    public bool IsOld { get; private set; }   // om det gått 10 dagar så hamnar den i i gamla listan

    public Message(string rubric, string content, int idFromUser, int idToUser)
    {
        Rubric = rubric; // annonsrubriken?
        Content = content;
        IDFromUser = idFromUser;
        IDToUser = idToUser;
        DateSent = DateTime.Now;
    }
    public Message() { }

    public bool IsMessageOld()
    {
        if (DateTime.Now > DateSent.AddDays(14))
        {
            IsOld = true;
        }
        else
        {
            IsOld = false;
        }
        return IsOld;
    }

    public string MessagesToString()
    {
        return $"Message id [{ID}]: {Rubric} From {idfromuser}";
    }
    public string WholeMessageToString()
    {
        return $"{Rubric}\n\r{Content}\n\r//{idfromuser}";
    }

}