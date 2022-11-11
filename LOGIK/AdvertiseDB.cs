using Dapper;
using MySqlConnector;
namespace LOGIK;
public class AddvertiseDb : IAdManagement
{


    //Klass för att hålla funktioner för annonserna
    List<advertise> ads = new(); //Ska hålla annonserna

    public void CreateAd(advertise advertise)
    {
        List<advertise> CreateAd = new();

        int rowsEffected = 0;

        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO advertise(rubric,description,price,municipality,county,postal_number,user_id)VALUES(@rubric,@description,@price,@county,@municipality,@postalNumber, @userid);";

            rowsEffected = con.ExecuteScalar<int>(query, param: advertise);
        }
        if (rowsEffected >= 1)
        {
            Console.WriteLine("Kund las in.");
        }
        else
        {
            Console.WriteLine("Något gick fel.");
        }

    }

    public void RemoveAd(advertise advertise)
    {

        int rowsEffected = 0;

        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "DELETE FROM advertise WHERE id = @id;";

            rowsEffected = con.ExecuteScalar<int>(query, param: advertise);
        }
        if (rowsEffected >= 1)
        {
            Console.WriteLine("Annons togs bort");
        }
        else
        {
            Console.WriteLine("Något gick fel.");
        }

    }

    public List<advertise> ShowAllAds(string search)

    {
        List<advertise> allAds = new();


        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "SELECT rubric,description,price,municipality,county FROM advertise WHERE rubric = @rubric";

            allAds = con.Query<advertise>(query, new { @search = search }).ToList();
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