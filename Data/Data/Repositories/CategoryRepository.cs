using Data.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(ReadLaterDataContext context) : base(context) { }
        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }
        public void Delete(Category entity)
        {
            _db.Categories.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }

        public Category GetById(int id)
        {
            return _db.Categories.SingleOrDefault(c => c.ID == id);
        }

        public void Update(Category entity)
        {
            _db.Categories.Update(entity);
            _db.SaveChanges();
        }
    }
}
