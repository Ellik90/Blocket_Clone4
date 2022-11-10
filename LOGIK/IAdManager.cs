public interface IAdManagement
{
    //Interface för funktioner av annonser
    public void CreateAd(advertise advertise);

    public void RemoveAd(advertise advertise);

    public List <advertise> ShowAd(advertise advertise);

    public void AdOverview(advertise advertise);
}
