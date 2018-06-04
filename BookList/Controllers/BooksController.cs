using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookList.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var books = from b in _db.Books orderby (b.Name) select b;
            if (!String.IsNullOrEmpty(searchString))
            {
               var searchBooks = books.Where(b => b.Name.Contains(searchString));
                return View(searchBooks.ToList());
            }
                // var books = (from b in _db.Books orderby (b.Name) select b);
                return View(books.ToList());
        }

        //Get : Book/Create
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if(ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }


        //Details : Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            
            if (book == null)
            {
                return NotFound();
            }

            return View(book);

        }

        //POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Update(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);


            if (book == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        //POST: Book/delte/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }






        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
            //base.Dispose(disposing);
        }
    }
}