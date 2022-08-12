using BigBazzar.Models;
using BigBazzar.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo _repository;
        public AdminController(IAdminRepo repository)
        {
            _repository = repository;
        }
        [HttpPost("AddAdmin")]
        public async Task<ActionResult<Admin>> PostAdmin(Admin A)
        {
            return await _repository.AddNewAdmin(A);
        }
        [HttpPost("DeleteAdmin")]
        public async Task AdminDelete(int AdminId)
        {
            await _repository.DeleteAdmin(AdminId);
        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult<Categories>> PostCategory(Categories C)
        {
            return await _repository.AddNewCategory(C);
        }
        [HttpPost("DeleteCategory")]
        public async Task DeleteCategory(int CategoryId)
        {
            await _repository.DeleteCategory(CategoryId);   
        }
    }
}
