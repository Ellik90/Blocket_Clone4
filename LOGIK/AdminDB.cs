using Dapper;
using MySqlConnector;
namespace LOGIK;
public class AdminDB 
{
        public int CreateAdmin(Admin admin)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO users(social_security_number,admin_name,email,role,date,pass_word)VALUES(@SocialSecurityNumber,@Name,@email,@role,@date,@PassWord);";
            rows = connection.ExecuteScalar<int>(query, param: admin);
        }
      return rows;
    }
}