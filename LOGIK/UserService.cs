namespace LOGIK;
public class UserService : IuserService, IUserHandeler
{
    //här i är funktioner mellan anv och db, tex makenewuser(string name, string email) eller makenewuser(User user)samt kontrollerare osv;

    IUserHandeler _userHandele;
    IIdentifier _identifier;
    IUserEditor _userEditor;

    public UserService(IIdentifier identifier, IUserHandeler userHandeler, IUserEditor userEditor)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
        _userEditor = userEditor;
    }

    public User GetTheUser(User user)
    {
       List<User> users = _userHandele.GetUser();
       User getUser = new();

       foreach(User auser in users)
       {
        if(auser.Id == user.Id)
        {
            getUser = auser;
        }
        else
        {
            Console.WriteLine("something went wrong");
          
        }    
       }
       return getUser;    
               
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
        _userEditor.UpDateDescription(user, updateDescription);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int NicknameExists(string nickname)
    {
        throw new NotImplementedException();
    }

    public int CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public int UserLogInExists(User user)
    {
        throw new NotImplementedException();
    }

    public int UserEmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public int DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public int GetUserIdFromAdvertise(int advertiseId)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUser()
    {
        throw new NotImplementedException();
    }
}