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

    }
    public void CheckAd(int advertiseID)
    {
        _advertiseService.CheckAd(advertiseID);
    }
}