namespace LOGIK;
public class Message
{
    public int ID{get;private set;}
    public int IDFromUser{get;private set;}
    public int IDToUser{get;private set;}
    public string Rubric{get;private set;}
    public string Content{get;private set;}
    public readonly DateTime DateSent;
    // public annons annons;
    public bool IsOld{get; private set;}   // om det gått 10 dagar så hamnar den i i gamla listan

    public Message(string rubric, string content)
    {
        Rubric =  rubric; // annonsrubriken?
        Content = content;
        DateSent = DateTime.Now;
    }
    public Message(){}

    public bool IsMessageOld()
    {
        if(DateTime.Now > DateSent.AddDays(14))
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
        return $"{ID}: {Rubric}";
    }
    public string WholeMessageToString()
    {
        return $"{Rubric}\n\rANNONSNAMNET\n\r{Content}";
    }

}