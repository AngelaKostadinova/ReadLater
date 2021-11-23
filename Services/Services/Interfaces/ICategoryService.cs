using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(string userId);
        Category GetCategoryById(int id, string userId);
        Category GetCategoryById(int id);
        void CreateCategory(Category category, string userId);
        void DeleteCategory(Category category, string userId);
        void UpdateCategory(Category category, string userId);
    }
}
