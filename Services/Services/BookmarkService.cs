﻿using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;

        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }
        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }
        public void UpdateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public Bookmark GetBookmark(int Id)
        {
            return _ReadLaterDataContext.Bookmark.Where(b => b.ID == Id).FirstOrDefault();
        }

        public Bookmark GetBookmark(string Url)
        {
            return _ReadLaterDataContext.Bookmark.Where(b => b.URL == Url).FirstOrDefault();
        }

        public List<Bookmark> GetBookmarks()
        {
            return _ReadLaterDataContext.Bookmark.ToList();
        }
        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }
    }
}