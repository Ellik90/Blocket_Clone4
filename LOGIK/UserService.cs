namespace LOGIK;
public class UserService
{
    //här i är funktioner mellan anv och db, tex makenewuser(string name, string email) eller makenewuser(User user)samt kontrollerare osv;

    IUserHandeler _userHandele;

    IIdentifier _identifier;

    public UserService(IIdentifier identifier, IUserHandeler userHandeler)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
    }

    public void GetUserIdToAD(IUserHandeler userHandeler, int advertiseId)
    {
        userHandeler.GetUserIdFromAdvertise(advertiseId);
        Console.WriteLine("You got an ID ");
    }
    public void MakeUser(IUserHandeler iuserhandeler, User user)
    {
        iuserhandeler.BecomeNewUser(user);
        Console.WriteLine("yeey");
    }

    public void CheckNickNameExists(IUserHandeler iuserHandeler, string nickName)
    {
        iuserHandeler.NicknameExists(nickName);
        Console.WriteLine("Working");
    }

    public void DeleteTheUser(IUserHandeler userHandeler, User user)
    {       
        userHandeler.DeleteUser(user);
        Console.WriteLine("User deleted");
    }
}