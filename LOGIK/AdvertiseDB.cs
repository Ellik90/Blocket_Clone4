using Dapper;
using MySqlConnector;
namespace LOGIK;
public class AddvertiseDb : IAdManagement
{
        /*this.rubric = rubric;
        this.description = description;
        this.price = price;
        this.location = location;
        this.municipality = municipality;
        this.postalNumber = postalNumber;*/

    //Klass för att hålla funktioner för annonserna
    List<advertise> ads = new(); //Ska hålla annonserna

    public void CreateAd(advertise advertise)
    {
        List<advertise> CreateAd = new();

        int rowsEffected = 0;

        using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO advertise(category,sub_category,picture,rubric,description,price,municipality,county)VALUES(@rubric,@description,@price,@location,@municipality,@postalNumber);";

            rowsEffected = con.ExecuteScalar<int>(query, param: advertise);
        }
        if(rowsEffected >= 1)
        {
            Console.WriteLine("Kund las in.");
        }
        else
        {
            Console.WriteLine("Något gick fel.");
        }
        
    }

    public void AdOverview(advertise advertise)
    {
        
    }

    public void RemoveAd(advertise advertise)
    {
        
    }

    public List<advertise> ShowAd(advertise advertise)
    {
        return new List<advertise>();
    }



}