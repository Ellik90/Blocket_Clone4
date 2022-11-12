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

    public int NicknameExists(string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE nick_name = @name";
            rows = connection.ExecuteScalar<int>(query, new { @name = nickname });
        }
     return rows;
    }

    public int BecomeNewUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO users(nick_name,social_security_number,email, adress,pass_word)VALUES(@name,@SocialSecurityNumber,@email,@adress,@passWord);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
      return rows;
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

    public int UserEmailExists(string Email)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM users WHERE email = @email ";
            rows = connection.ExecuteScalar<int>(query, new { @email = Email });
        }
        return rows;
    }

    public int DeleteUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "DELETE FROM user_message WHERE from_user_id = @id OR to_user_id = @id; DELETE FROM users WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, new { @id = user.Id });//DET GÅR INTE ATT RADERA FÖR FOREIGN KEY, MESSAGE
        }
        return rows;
    }

    public int UpdateEmail(User user, string userEmail)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET email = @userEmail WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @userEmail = userEmail, @id = user.Id });
        }
        return rows;
    }

    public int UpdateNickName(User user, string nickname)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET nick_name = @nickName WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @nick_name = nickname, @id = user });
        }
        return rows;
    }
    public int UpDateDescription(User user, string updateDescription)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE users SET description = @description WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @description = updateDescription, @id = user.Id });
        }
        return rows;
    }
}