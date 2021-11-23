using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadLater5.Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    public class BookmarkController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;

        public BookmarkController(IBookmarkService bookmarkService, ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Bookmark> model = _bookmarkService.GetAllBookmarks(userId).ToList();
            return View(model);
        }

         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _bookmarkService.CreateBookmark(bookmark, userId);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id, userId);

            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _bookmarkService.UpdateBookmark(bookmark, userId);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id, userId);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Bookmark bookmark = _bookmarkService.GetBookmarkById(id, userId);
            _bookmarkService.DeleteBookmark(bookmark, userId);
            return RedirectToAction("Index");
        }
    }
}
