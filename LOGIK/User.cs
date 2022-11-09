namespace LOGIK;
public class User
{
    List<Message> messages = new();

    public int Id { get; set; }
    public int Password { get; set; }
    public string? Name { get; set; }
    public string? SocialSecurityNumber { get; set; }
    public string? Adress { get; set; }
    public string? Email { get; set; }
    public readonly DateTime Openaccount;

    public User(string name, string SocialSecurityNumber, string adress, string email, int password)
    {
        Openaccount = DateTime.Now;
    }
    public User()
    {

    }

}