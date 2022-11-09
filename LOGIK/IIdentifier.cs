namespace LOGIK;
public interface IIdentifier
{
    public bool ValidateSocialSecurityNumber(string socNo);
    public bool ValidateEmail(string email);
    public int SendEmailWithCode(string email);
    public bool CheckIfUserExists(IUserHandeler userHandeler, User user);  
}