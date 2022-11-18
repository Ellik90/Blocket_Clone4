using TYPES;
using DATABASE;
namespace LOGIK;
public class UserService : IUserService
{
    //här i är funktioner mellan anv och db, tex makenewuser(string name, string email) eller makenewuser(User user)samt kontrollerare osv;

    IUserHandeler _userHandeler;
    IUserEditor _userEditor; 
    public UserService(IUserHandeler userHandeler, IUserEditor userEditor)
    {
        _userHandeler = userHandeler;
        _userEditor = userEditor;
    }
    public User GetTheUser(User user)
    {
       List<User> users = _userHandeler.GetUser();
       User getUser = new();

       foreach(User auser in users)
       {
        if(auser.Id == user.Id)
        {
            getUser = auser;
        }
       }
       return getUser;    
               
    }

    public bool GetUserIdToAD(int advertiseId)
    {
        // ADVERTISE SERVICE METOD SOM HÄMTAR ALLA ANNONS EGENSKAPER, SEN SKICKAR VIDARE USERID
        int rows = 0;
        _userHandeler.GetUserIdFromAdvertise(advertiseId);
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
        _userHandeler.CreateUser(user);
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
        _userHandeler.NicknameExists(nickName);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     public bool CheckUserEmailExists(string Email)
    {
        int rows = 0;
        _userHandeler.UserEmailExists(Email);
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
        _userHandeler.DeleteUser(user);
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
     public bool UpdateEmail(User user, string userEmail)
    {
        int rows = 0;
        _userEditor.UpdateEmail(user, userEmail);
          if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
      public bool UpdateNickname(User user, string updateNickname)
    {
        int rows = 0;
        _userEditor.UpdateNickName(user, updateNickname);
           if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool UpDateDescription(User user, string updateDescription)
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
     public bool UpDatePassword(User user, string passWord)
    {
       int rows = 0;
       _userEditor.UpDatePassword(user, passWord);
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