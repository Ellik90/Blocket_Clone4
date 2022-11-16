using LOGIK;
using TYPES;

class advertiseoperator
{
    IAdvertiseService _advertiseService;

    public advertiseoperator(AdvertiseService _advertiseService)
    {
        this._advertiseService = _advertiseService;
        
    }
    public void CreateAd(User user)
    {
        string rubric = ConsoleInput.GetString("Advertise rubric: ");
        string description = ConsoleInput.GetString("Advertise description");
        float price = ConsoleInput.GetFloat("Advertise price: ");
        string county = ConsoleInput.GetString("Advertise location county: ");
        string municipality = ConsoleInput.GetString("Advertise location municipality: ");
        int postalNumber = ConsoleInput.GetInt("Advertise location postal number: ");
        int userId = user.Id;  // HÄR TA IN USER OCH TA DENS ID HÄR

        Advertise advertise = new(rubric, description, price, county, municipality, postalNumber, userId);

        _advertiseService.MakeNewAd(advertise);

        // till service makead?? 
        // den är inlagd meddelande?
    }
    public void CheckAd(int advertiseID)
    {
        _advertiseService.CheckAd(advertiseID);
    }
}