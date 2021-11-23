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
    public class BookmarkService : IBookmarkService
    {
        protected readonly IRepository<Bookmark> _bookmarkRepository;
        protected readonly IApplicationUserRepository _userRepository;
        protected readonly IRepository<Category> _categoryRepository;

        public BookmarkService(IRepository<Bookmark> bookmarkRepository,
                            IApplicationUserRepository userRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _userRepository = userRepository;
        }
        public void AddHit(Bookmark bookmark, string userId)
        {
            throw new NotImplementedException();
        }

        public void CreateBookmark(Bookmark bookmark, string userId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var bookmarkModel = new Bookmark()
                {
                    CreateDate = bookmark.CreateDate,
                    ShortDescription = bookmark.ShortDescription,
                    URL = bookmark.URL,
                    User = user,
                    Category = bookmark.Category
                };

                _bookmarkRepository.Add(bookmarkModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBookmark(Bookmark bookmark, string userId)
        {
            try
            {
                var bookmarkFound = _bookmarkRepository.GetAll().FirstOrDefault(b => b.ID == bookmark.ID && b.UserId == userId);

                _bookmarkRepository.Delete(bookmarkFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public IEnumerable<Bookmark> GetAllBookmarks(string userId)
        {
            IEnumerable<Bookmark> bookmarks = _bookmarkRepository.GetAll().ToList().Where(b => b.UserId == userId);

            return bookmarks;
        }

        public Bookmark GetBookmarkById(int id, string userId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetById(userId);
                Bookmark bookmark = _bookmarkRepository.GetById(id);

                if (user.Id == bookmark.UserId)
                {
                    return bookmark;
                }
                else
                {
                    return new Bookmark();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bookmark GetBookmarkById(int id)
        {
            try
            {
                return _bookmarkRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Bookmark does not exist!", ex);
            }
        }

        public void UpdateBookmark(Bookmark bookmark, string userId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetById(userId);

                if (user.Id == bookmark.UserId)
                {
                    _bookmarkRepository.Update(bookmark);
                }
                else
                {
                    throw new Exception("You can't update that bookmark");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
