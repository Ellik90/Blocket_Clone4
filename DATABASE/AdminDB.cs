using Dapper;
using MySqlConnector;
using TYPES;
namespace DATABASE;
public class AdminDB : IAdmin, IAdminEditor
{
    //Admin granskaannons metod is_checked, är den granskad
    
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
    public int AdminLogInExists(Admin admin)
    {
        // EGEN DB KLASS
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM admins WHERE email = @email AND pass_word = @password; SELECT LAST_INSERT_ID() ";
            id = connection.ExecuteScalar<int>(query, param: admin);
            return id;
        }
    }
    public int AdminEmailExists(string Email)
    {
        //EGEN DB KLASS?
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM admins WHERE email = @email";
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
    public List<Admin> GetAdmins(Admin admin)
    {
        List<Admin> admins = new();

        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT id AS 'id', social_security_number AS 'socialsecuritynumber',admin_name AS 'name', email AS 'email', role AS 'admin_role', pass_word AS 'password' FROM admins;";
            admins = connection.Query<Admin>(query).ToList();
            return admins;
        }
    }

       public int UpdateAdminEmail(Admin admin, string adminEmail)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE admins SET email = @adminEmail WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @adminEmail = adminEmail, @id = admin.Id });
        }
        return rows;
    }

        public int UpdateAdminName(Admin admin, string name)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE admins SET admin_name = @name WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @admin_name = name, @id = admin });
        }
        return rows;
    }

     

}