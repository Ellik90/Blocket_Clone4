using TYPES;
using DATABASE;
namespace LOGIK
{
    public interface IAdvertiseService
    {
        public int MakeNewAd(Advertise advertise);
        public List<Advertise> SearchAd(string search);
        public void RemoveOneAd(int id);
        public Advertise ShowOneAd(int id);
        public void CheckAd(int id);
    }
}