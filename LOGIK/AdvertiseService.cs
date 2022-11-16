using TYPES;
using DATABASE;
namespace LOGIK;
public class AdvertiseService : IAdvertiseService
{
    //Sökmetod 
    IAdHandler _IadManager;
    List<Advertise> listOfAdvertise = new List<Advertise>();

    public AdvertiseService(IAdHandler _IadManager)
    {
        this._IadManager = _IadManager;
    }
    public int MakeNewAd(Advertise advertise)
    {
        return _IadManager.CreateAd(advertise);
    }
    public List<Advertise> SearchAd(string search) //Sökmetod för rubriker/beskrvning
    {

        List<Advertise> findAd = _IadManager.ShowAllAds();

        List<Advertise> foundAds = new();

        foreach (Advertise item in findAd)
        {
            if (item.Rubric.ToLower() == search.ToLower() && item.isChecked == true)
            {
                foundAds.Add(item);

            }
            else if (item.Description.ToLower() == search.ToLower() && item.isChecked == true)
            {
                foundAds.Add(item);
            }

        }
        return foundAds;

    }
    public void RemoveOneAd(int id)
    {
        _IadManager.RemoveAd(id);

        foreach (Advertise item in listOfAdvertise)
        {
            if(id == item.Id)
            {
                listOfAdvertise.Remove(item);

            }
        }

    }
    public Advertise ShowOneAd(int id)
    {
        return _IadManager.ShowAd(id);
    }

    public void CheckAd(int id)
    {
        _IadManager.CheckAds(id);
    }
    // här finns funktioner som hanterar advertise, mellan användare och databasen
    //här in behövs ju då komma ett interface IAdManager adManager; behöver finnas tex via konstruktorn
    // tex  makenewad(string rubric, float price....);

}