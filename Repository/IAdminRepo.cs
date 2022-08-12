using BigBazzar.Models;

namespace BigBazzar.Repository
{
    public interface IAdminRepo
    {
        Task<Admin> AddNewAdmin(Admin A);
        Task DeleteAdmin(int AdminId);
        Task<Categories> AddNewCategory(Categories category);
        Task DeleteCategory(int CategoryId);
        Task<Admin> EditAdmin(int AdminId);
    }
}
