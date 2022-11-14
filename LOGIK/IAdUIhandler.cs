namespace LOGIK
{
    public interface IAdUIhandler
    {
        public int MakeNewAd(Advertise advertise);
        public List<Advertise> SearchAd(string search);
        public void RemoveOneAd(int id);
        public Advertise ShowOneAd(int id);
    }
}