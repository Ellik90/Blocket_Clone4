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
  public void MakeNewAd(advertise advertise)
  {
    _IadManager.CreateAd(advertise);
  }
    // här finns funktioner som hanterar advertise, mellan användare och databasen
    //här in behövs ju då komma ett interface IAdManager adManager; behöver finnas tex via konstruktorn
    // tex  makenewad(string rubric, float price....);
    
}