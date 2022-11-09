using Dapper;
using MySqlConnector;
namespace LOGIK;
public class UserDB : IUserHandeler
{
    public bool NicknameExists(string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE nick_name = @name";
            rows = connection.ExecuteScalar<int>(query, param: nickname);
        }
         if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BecomeNewUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO users(nick_name,social_security_number,email,pass_word)VALUES(@name,@SocialSecurityNumber,@email,@passWord);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        
    }
    public bool UserExists(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE email = @email AND pass_word = @password ";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool DeleteUser(User deleteUser)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "DELETE FROM users WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: deleteUser);
        }
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateEmail(User user, string userEmail)
    {
        Console.WriteLine("email updated");
        throw new NotImplementedException();
    }

    public void UpdateNickName(User user, string nickname)
    {
        Console.WriteLine("Nickname updatet");
        throw new NotImplementedException();
    }
    public void UpDateDescription(User user, string updateDescription)
    {
        Console.WriteLine("Descript update");
        throw new NotImplementedException();
    }

}