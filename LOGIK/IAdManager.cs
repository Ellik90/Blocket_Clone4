namespace LOGIK;
public interface IAdManagement
{
    //Interface för funktioner av annonser
    public int CreateAd(advertise advertise);

    public void RemoveAd(int id);

    public List <advertise> ShowAllAds();

    public void AdOverview(advertise advertise);

    public advertise ShowAd(int id);
  
}
