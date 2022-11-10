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
            string query = "INSERT INTO users(nick_name,social_security_number,email, adress,pass_word)VALUES(@name,@SocialSecurityNumber,@email,@adress,@passWord);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }

    }
    //hämta ut id från user
    //testa alla querys i databasen
    public bool UserLogInExists(User user)
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

    public bool UserEmailExists(string Email)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE email = @email ";
            rows = connection.ExecuteScalar<int>(query, param: Email);
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

    public bool UpdateEmail(User user, string userEmail)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET email = @userEmail WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @email = userEmail, @id = user });
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

    public void UpdateNickName(User user, string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET nick_name = @nickName WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @nick_name = nickname, @id = user });
        }
    }
    public void UpDateDescription(User user, string updateDescription)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET description = @description WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @description = updateDescription, @id = user });
        }
    }

}