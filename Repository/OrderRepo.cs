using BigBazzar.Data;
using BigBazzar.Models;

namespace BigBazzar.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BigBazzarContext _context;
        public OrderRepo(BigBazzarContext context)
        {
            _context = context;
        }

        public async Task<OrderDetails> AddOrderDetail(OrderDetails orderDetail)
        {

            _context.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<OrderMasters> AddOrderMaster(OrderMasters orderMaster)
        {
            _context.Add(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        //public async Task<OrderMasters> DeleteOrderMaster(int id)
        //{
        //    OrderMasters om=_context.OrderMasters.Find(id);
        //    _context.OrderMasters.Remove(om);
        //   await _context.SaveChangesAsync();
        //}

        public async Task<OrderDetails> GetOrderDetailById(int orderDetailId)
        {
            var od = await _context.OrderDetails.FindAsync(orderDetailId);
            return od;
        }

        public async Task<OrderMasters> GetOrderMasterById(int orderMasterId)
        {

            var od = await _context.OrderMasters.FindAsync(orderMasterId);
            return od;
        }

        public async Task<OrderMasters> UpdateOrderMaster(int id, OrderMasters orderMaster)
        {
            if (orderMaster.AmountPaid == orderMaster.Total)
            {

                _context.Update(orderMaster);
                await _context.SaveChangesAsync();
                List<Carts> c = (from i in _context.Carts where i.CustomerId == orderMaster.CustomerId select i).ToList();
                foreach(var cart in c)
                {
                    Products P = (from m in _context.Products where m.ProductId == cart.ProductId select m).Single();
                    P.ProductQuantity -= cart.ProductQuantity;
                    _context.Update(P);
                    _context.Carts.Remove(cart);
                    await _context.SaveChangesAsync(true);
                }
                return orderMaster; 
            }
            else
            {
                //List<OrderDetails> od = (from i in _context.OrderDetails where i.OrderMasterId == orderMaster.OrderMasterId select i).ToList();
                //foreach(OrderDetails orderdetail in od)
                //{
                //    _context.Remove(orderdetail);   
                //}
                //_context.Remove(orderMaster);
                //await _context.SaveChangesAsync();
                return null;
            }

        }
    }
}
