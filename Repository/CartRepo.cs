using BigBazzar.Data;
using BigBazzar.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBazzar.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly BigBazzarContext _context;
        public CartRepo(BigBazzarContext context)
        {
            _context = context;
        }

        public async Task<Carts> AddToCart(Carts cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task DeleteFromCart(int id)
        {
            try
            {
                Carts carts = _context.Carts.Find(id);
                _context.Carts.Remove(carts);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Carts> EditCart(int id,Carts C)
        {
            _context.Update(C);
            _context.SaveChanges();
            return C;
        }

        public Task<List<Carts>> GetAllCart(int customerId)
        {
            var cartList = (from c in _context.Carts where c.CustomerId == customerId select c).ToListAsync();
            return cartList;
        }
        public async Task<Carts> GetCartById(int id)
        {
            return await _context.Carts.FindAsync(id);

        }
    }
}
