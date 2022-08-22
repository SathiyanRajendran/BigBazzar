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

        public async Task<Carts>? AddToCart(Carts cart)
        {
            if(await isCartExists(cart))
            {
                return cart;
            }
            else
            {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
            }
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

        public async Task<List<Carts>> GetAllCart(int customerId) //get all products of the cart by the customerid
        {
            List<Carts> cartList =await (from c in _context.Carts.Include(x => x.Products) where c.CustomerId == customerId select c).ToListAsync();
            return cartList;
        }
        public async Task<Carts> GetCartById(int cartid)
        {
            var result = await (from c in _context.Carts.Include(x => x.Products) where c.CartId == cartid select c).SingleAsync();
            return result;
        }
        private async Task<bool> isCartExists(Carts ct)
        {
            var cart = (from c in _context.Carts where c.ProductId == ct.ProductId && c.CustomerId == ct.CustomerId select c).FirstOrDefault();
            
            if(cart==null)
            {
                return false;
            }
            else
            {
                cart.ProductQuantity += ct.ProductQuantity;
                _context.Carts.Update(cart);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
