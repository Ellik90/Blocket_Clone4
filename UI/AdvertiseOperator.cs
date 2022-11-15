using LOGIK;

class advertiseoperator
{
    IAdvertiseService _advertiseService;

    public advertiseoperator(AdvertiseService _advertiseService)
    {
        this._advertiseService = _advertiseService;
        
    }
    public void CreateAd()
    {
        string rubric = ConsoleInput.GetString("Rubric on advertise: ");



        // Advertise advertise = new(rubric,);
        // till service makead?? 
        // den är inlagd meddelande?
    }
    public void CheckAd(int advertiseID)
    {
        _advertiseService.CheckAd(advertiseID);
    }
}