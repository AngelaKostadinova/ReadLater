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
    public class BookmarkRepository : BaseRepository, IRepository<Bookmark>
    {
        public BookmarkRepository(ReadLaterDataContext context) : base(context) { }

        public void Add(Bookmark entity)
        {
            _db.Bookmark.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Bookmark entity)
        {
            _db.Bookmark.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Bookmark> GetAll()
        {
            return _db.Bookmark.Include(x => x.Category);
        }

        public Bookmark GetById(int id)
        {
            return _db.Bookmark.Include(x => x.Category).SingleOrDefault(x => x.ID == id);
        }

        public void Update(Bookmark entity)
        {
            _db.Bookmark.Update(entity);
            _db.SaveChanges();
        }
    }
}
