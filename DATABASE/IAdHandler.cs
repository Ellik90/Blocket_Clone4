using TYPES;
namespace DATABASE;
public interface IAdHandler
{
    //Interface för funktioner av annonser
    // alla metoder i advertisedb ska vara skrivna här 
    public int CreateAd(Advertise advertise);

   public int GetUserIdFromAdvertise(int advertiseId);

    public void RemoveAd(int id);

    public List <Advertise> ShowAllAds();

    public void AdOverview(Advertise advertise);

    public Advertise ShowAd(int id);

    public void CheckAds(int id);
    public List <Advertise> ShowMyads(int id);
  
}
