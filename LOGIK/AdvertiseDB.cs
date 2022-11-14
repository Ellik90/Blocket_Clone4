using Dapper;
using MySqlConnector;
namespace LOGIK;
public class AddvertiseDb : IAdHandler
{


    //Klass för att hålla funktioner för annonserna
    List<advertise> ads = new(); //Ska hålla annonserna

    public int CreateAd(advertise advertise)
    {
        List<advertise> CreateAd = new();

        int id = 0;

        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO advertise(rubric,description,price,municipality,county,postal_number,user_id)VALUES(@rubric,@description,@price,@county,@municipality,@postalNumber, @userid); SELECT LAST_INSERT_ID();" ;

            id = con.ExecuteScalar<int>(query, param: advertise);
        }
        if (id >= 1 )
        {
            Console.WriteLine("Registrerad.");
        }
        else
        {
            Console.WriteLine("Något gick fel.");
        }
        return id;

    }

    public void RemoveAd(int id)
    {

        int rowsEffected = 0;

        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "DELETE FROM advertise WHERE id = @id;";

            rowsEffected = con.ExecuteScalar<int>(query, new{@id = id});
        }
        if (rowsEffected >= 1)
        {
            Console.WriteLine("Advertise removed");
        }
        else
        {
            Console.WriteLine("Something went wrong.");
        }

    }

    public List<advertise> ShowAllAds()

    {
        List<advertise> allAds = new();


        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT rubric,description,price,municipality,county FROM advertise";

            allAds = con.Query<advertise>(query).ToList();
        }

        return allAds;
    }
    public advertise ShowAd(int id)
    {
        advertise advertise = new();

         using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT rubric,description,price,municipality,county,user_id AS 'userID' FROM advertise WHERE id = @id;";

            advertise = con.QuerySingle<advertise>(query, new { @id = id });
        }
        return advertise;
        //all info, även userid 

    }
    public void AdOverview(advertise advertise)
    {

    }



}