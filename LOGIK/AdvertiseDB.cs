 using Dapper;
 using MySqlConnector;
 namespace LOGIK;
 public class AddvertiseDb : IAdManagement
{
    //Klass för att hålla funktioner för annonserna
    List<advertise> ads = new(); //Ska hålla annonserna

    public void AdOverview() //Implement från IAdManagement
    {
        throw new NotImplementedException();
    }

    public List <advertise> CreateAd()
    {
        List <advertise> CreateAd = new();

        throw new NotImplementedException();
    }

    public void RemoveAd()
    {
        throw new NotImplementedException();
    }

    public List <advertise> ShowAd()
    {
        return ads;
        throw new NotImplementedException();
    }
}