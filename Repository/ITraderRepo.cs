using BigBazzar.Models;

namespace BigBazzar.Repository
{
    public interface ITraderRepo
    {
        Task<List<Traders>> GetAllTraders();
        Task<Traders> GetTraderbyId(int TraderId);
        Task<Traders> AddNewTraders(Traders T);
        Task<Traders> UpdateTraders(int TraderId, Traders T);
        Task<Traders> TraderLogin(Traders T);
        Task DeleteTraders(int TraderId);
    }
}
