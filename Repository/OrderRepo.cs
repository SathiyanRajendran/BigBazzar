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

            _context.Update(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster ;
        }
    }
}
