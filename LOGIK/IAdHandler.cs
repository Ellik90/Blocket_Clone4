namespace LOGIK;
public interface IAdHandler
{
    //Interface för funktioner av annonser
    public int CreateAd(advertise advertise);

    public void RemoveAd(int id);

    public List <advertise> ShowAllAds();

    public void AdOverview(advertise advertise);

    public advertise ShowAd(int id);
  
}
