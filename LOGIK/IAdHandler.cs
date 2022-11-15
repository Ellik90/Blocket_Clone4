namespace LOGIK;
public interface IAdHandler
{
    //Interface för funktioner av annonser
    public int CreateAd(Advertise advertise);

    public void RemoveAd(int id);

    public List <Advertise> ShowAllAds();

    public void AdOverview(Advertise advertise);

    public Advertise ShowAd(int id);

    public void CheckAds(int id);
  
}
