using Dapper;
using MySqlConnector;
namespace LOGIK;
public class UserDB : IUserHandeler
{

    public int GetUserIdFromAdvertise(int advertiseId)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;")) 
        {
            string query = "SELECT user_id FROM advertise WHERE id = @id";
            id = connection.ExecuteScalar<int>(query, new { @id = advertiseId });
            return id;
        }       
    }

    public bool NicknameExists(string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE nick_name = @name";
            rows = connection.ExecuteScalar<int>(query, new { @name = nickname });
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
    public bool BecomeNewUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO users(nick_name,social_security_number,email, adress,pass_word)VALUES(@name,@SocialSecurityNumber,@email,@adress,@passWord);";
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
    //hämta ut id från user
    //testa alla querys i databasen
    public int UserLogInExists(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE email = @email AND pass_word = @password; SELECT LAST_INSERT_ID() ";
            id = connection.ExecuteScalar<int>(query, param: user);
            return id;
        }


    }

    public bool UserEmailExists(string Email)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE email = @email ";
            rows = connection.ExecuteScalar<int>(query, new { @email = Email });
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
    public bool DeleteUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "DELETE FOREIGN KEY DELETE DELETE FROM users WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, new { @id = user.Id});//DET GÅR INTE ATT RADERA FÖR FOREIGN KEY, MESSAGE
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
            rows = connection.ExecuteScalar<int>(query, param: new { @userEmail = userEmail, @id = user.Id });
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

    public bool UpdateNickName(User user, string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET nick_name = @nickName WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @nick_name = nickname, @id = user });
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
    public bool UpDateDescription(User user, string updateDescription)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET description = @description WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @description = updateDescription, @id = user });
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

}