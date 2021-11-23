using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookmarkService
    {
        IEnumerable<Bookmark> GetAllBookmarks(string userId);
        Bookmark GetBookmarkById(int id, string userId);
        Bookmark GetBookmarkById(int id);
        void CreateBookmark(Bookmark bookmark, string userId);
        void DeleteBookmark(Bookmark bookmark, string userId);
        void UpdateBookmark(Bookmark bookmark, string userId);
        void AddHit(Bookmark bookmark, string userId);
    }
}
