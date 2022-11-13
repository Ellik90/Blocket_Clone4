namespace LOGIK;
public class AdvertiseService
{
    //Sökmetod 
    IAdManagement _IadManager; 
    List <advertise> listOfAdvertise = new List<advertise>();

  public AdvertiseService(IAdManagement _IadManager)
  {
    this._IadManager = _IadManager;
  }
  public int MakeNewAd(advertise advertise)
  {
    return _IadManager.CreateAd(advertise);
  }
  public List<advertise> SearchAd (string search) //Sökmetod för rubriker/beskrvning
  {

    List<advertise> findAd = _IadManager.ShowAllAds();
        foreach(advertise item in findAd)
        {
            if(item.Rubric.ToLower() == search.ToLower())
            {
                findAd.Add(item);

            }
            else if(item.Description.ToLower() == search.ToLower())
            {
                findAd.Add(item);
            }

        }   
        return findAd;

  }
  // public List <advertise> RemoveOneAd(int id)
  // {
  //   List <advertise> removeAds = _IadManager.RemoveAd();

  //   removeAds.RemoveAds();
  // }
    // här finns funktioner som hanterar advertise, mellan användare och databasen
    //här in behövs ju då komma ett interface IAdManager adManager; behöver finnas tex via konstruktorn
    // tex  makenewad(string rubric, float price....);
    
}