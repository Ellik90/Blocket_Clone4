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

    public User GetTheUser(User user)
    {
       List<User> users = _userHandele.GetUser();

       foreach(User auser in users)
       {
        if(auser == user)
        {
            return user;
        }
        else
        {
            Console.WriteLine("something went wrong");
        }        
       }
       return user;
               
    }

    public bool GetUserIdToAD(int advertiseId)
    {
        // ADVERTISE SERVICE METOD SOM HÄMTAR ALLA ANNONS EGENSKAPER, SEN SKICKAR VIDARE USERID
        int rows = 0;
        _userHandele.GetUserIdFromAdvertise(advertiseId);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool MakeUser(User user)
    {
        int rows = 0;
        _userHandele.CreateUser(user);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckNickNameExists(string nickName)
    {
        int rows = 0;
        _userHandele.NicknameExists(nickName);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteTheUser(User user)
    {
        int rows = 0;
        _userHandele.DeleteUser(user);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DescriptionInput(User user, string updateDescription)
    {
        int rows = 0;
        _userHandele.UpDateDescription(user, updateDescription);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}