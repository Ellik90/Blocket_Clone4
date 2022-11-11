public interface IAdManagement
{
    //Interface för funktioner av annonser
    public void CreateAd(advertise advertise);

    public void RemoveAd(advertise advertise);

    public List <advertise> ShowAllAds(string search);

    public void AdOverview(advertise advertise);

    public advertise ShowAd(int id);
  
}
