using BigBazzar.Models;

namespace BigBazzar.Repository
{
    public interface IOrderRepo
    {

        Task<OrderMasters> AddOrderMaster(OrderMasters orderMaster);
        Task<OrderMasters> UpdateOrderMaster(int id,OrderMasters orderMaster);
        Task<OrderMasters> GetOrderMasterById(int orderMasterId);
        Task<OrderDetails> GetOrderDetailById(int orderMasterId);
        Task<OrderDetails> AddOrderDetail(OrderDetails orderDetail);

    }
}
