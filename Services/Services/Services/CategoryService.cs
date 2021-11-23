using Data.Interfaces;
using Entity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly IApplicationUserRepository _userRepository;
        protected readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository,
                           IApplicationUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
        public void CreateCategory(Category category, string userId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var categoryModel = new Category()
                {
                    Name = category.Name,
                    User = user
                    
                };

                _categoryRepository.Add(categoryModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCategory(Category category, string userId)
        {
            try
            {
                var categoryFound = _categoryRepository.GetAll().FirstOrDefault(c => c.ID == category.ID && c.UserId == userId);

                _categoryRepository.Delete(categoryFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Category> GetAllCategories(string userId)
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll().ToList().Where(c => c.UserId == userId);

            return categories;
        }

        public Category GetCategoryById(int id, string userId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetById(userId);
                Category category = _categoryRepository.GetById(id);

                if (user.Id == category.UserId)
                {
                    return category;
                }
                else
                {
                    return new Category();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return _categoryRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Bookmark does not exist!", ex);
            }
        }

        public void UpdateCategory(Category category, string userId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetById(userId);
                category.User = user;
                category.UserId = user.Id;

                if (user.Id == category.UserId)
                {
                    _categoryRepository.Update(category);
                }
                else
                {
                    throw new Exception("You can't update that category");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
