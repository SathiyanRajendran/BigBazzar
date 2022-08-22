using BigBazzar.Models;
using BigBazzar.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderrepository;
        private readonly ICartRepo _cartrepository;
        public OrderController(IOrderRepo orderrepository, ICartRepo cartrepository)
        {
            _orderrepository = orderrepository;
            _cartrepository = cartrepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMasters>> GetOrderMaster(int id)
        {
            return await _orderrepository.GetOrderMasterById(id);
        }
        [HttpPut]
        public async Task<ActionResult<OrderMasters>> PutOrderMaster(int id, OrderMasters om)
        {
            return await _orderrepository.UpdateOrderMaster(id, om);
        }
        [HttpPost("orderMaster")]
        public async Task<ActionResult<OrderMasters>> PostOrderMaster(OrderMasters om)
        {
            return await _orderrepository.AddOrderMaster(om);
        }
        [HttpPost("orderDetail")]
        public async Task<ActionResult<OrderDetails>> PostOrderDetail(OrderDetails od)
        {
            return await _orderrepository.AddOrderDetail(od);
        }
        [HttpGet("orderDetail")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetail(int id)
        {
            return await _orderrepository.GetOrderDetailById(id);
        }
        [HttpPost("{customerid}")]
        public async Task<OrderMasters> Buy([FromRoute]int customerid)
        {
            List<Carts> c = await _cartrepository.GetAllCart(customerid);
            OrderMasters om = new OrderMasters();
            om.OrderDate = 0;
            om.CustomerId = customerid;
            om.Total = 0;
            if(c!=null)
            {
                foreach(var cart in c)
                {
                    om.Total += (cart.ProductQuantity * Convert.ToInt32(cart.Products.UnitPrice));

                }
            }
            await _orderrepository.AddOrderMaster(om);
            foreach(var item in c)
            {
                OrderDetails od = new OrderDetails();
                od.ProductId= item.ProductId;
                od.ProductQuantity= item.ProductQuantity;
                od.ProductRate = item.Products.UnitPrice;
                od.OrderMasterId = om.OrderMasterId;
                await _orderrepository.AddOrderDetail(od);
            }
            return om;
        }

    }
}
