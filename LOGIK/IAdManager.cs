public interface IAdManagement
{
    //Interface för funktioner av annonser
    public List <advertise> CreateAd();

    public void RemoveAd();

    public List <advertise> ShowAd();

    public void AdOverview();
}
