using BigBazzar.Data;
using BigBazzar.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBazzar.Repository
{
    public class TraderRepo : ITraderRepo
    {
        private readonly BigBazzarContext _context;
        public TraderRepo(BigBazzarContext context)
        {
            _context = context;
        }

        public async Task<Traders> AddNewTraders(Traders T)
        {
            _context.Traders.Add(T);
            await _context.SaveChangesAsync();
            return T;
        }

        public async Task DeleteTraders(int TraderId)
        {
            try
            {
                Traders T = _context.Traders.Find(TraderId);
                _context.Traders.Remove(T);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Traders>> GetAllTraders()
        {
            try
            {
                return await  _context.Traders.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();

            }
        }

        public async Task<Traders> GetTraderbyId(int TraderId)
        {
            return await  _context.Traders.FindAsync(TraderId);
        }

        public async Task<Traders> TraderLogin(Traders T)
        {
            var C = (from i in _context.Traders where i.TraderEmail == T.TraderEmail && i.Password == T.Password select i).FirstOrDefault();
            return C;
        }

        public async Task<Traders> UpdateTraders(int TraderId, Traders Trader)
        {
            _context.Update(Trader);
            _context.SaveChanges();
            return Trader;
        }
        private bool IsTrader(int id)
        {
            var traders = _context.Traders.Find(id);
            if(traders != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
