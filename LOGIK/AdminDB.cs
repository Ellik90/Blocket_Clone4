using Dapper;
using MySqlConnector;
namespace LOGIK;
public class AdminDB : IAdmin 
{
        public int CreateAdmin(Admin admin)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO admins(social_security_number,admin_name,email,pass_word)VALUES(@SocialSecurityNumber,@Name,@email,@PassWord);";
            rows = connection.ExecuteScalar<int>(query, param: admin);
        }
      return rows;
    }

       public int AdminEmailExists(string Email)
    {
        //EGEN DB KLASS?
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM admins WHERE email = @email ";
            rows = connection.ExecuteScalar<int>(query, new { @email = Email });
        }
        return rows;
    }
        public int AdminNameExists(string name)
    {
        //EGEN DB KLASS
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM admins WHERE admin_name = @name";
            rows = connection.ExecuteScalar<int>(query, new { @name = name });
        }
     return rows;
    }
     
      public int DeleteAdmin(Admin admin)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = " DELETE FROM admins WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, new { @id = admin.Id });//DET GÅR INTE ATT RADERA FÖR FOREIGN KEY, MESSAGE
        }
        return rows;      
    }
     
}