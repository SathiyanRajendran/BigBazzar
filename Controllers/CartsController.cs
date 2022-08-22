using BigBazzar.Models;
using BigBazzar.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepo _repository;
        public CartsController(ICartRepo repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        //get all carts of a particular customer by using the customer id
        public async Task<ActionResult<List<Carts>>> Getcarts(int id)
        {

            List<Carts> result =  await _repository.GetAllCart(id);
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Carts>> AddCart(Carts cart)
        {

            return await _repository.AddToCart(cart);
        }
        [HttpPut]
        public async Task<ActionResult<Carts>> UpdateCart(int id,Carts C)
        {
            return await _repository.EditCart(id,C);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCart(int id)
        {
            
            await _repository.DeleteFromCart(id);
            return NoContent();
        }

    }
}
