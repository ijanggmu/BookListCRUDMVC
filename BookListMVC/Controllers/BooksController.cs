using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index_Book()
        {
            try
            {
                var booklist = _db.Books.ToList();
                return View(booklist);
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Book b)
        {
            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    title = b.title,
                    author = b.author,
                    ISBN = b.ISBN
                };
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index_Book");
            }
            else
            {
                return View(b);
            }
        }
        public IActionResult Delete(int id)
        {
            var del = _db.Books.SingleOrDefault(e => e.id == id);
            _db.Books.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index_Book");
        }
        public IActionResult Edit(int id)
        {
            var edt = _db.Books.SingleOrDefault(e => e.id == id);
            var edtrst = new Book()
            {
                title = edt.title,
                author = edt.author,
                ISBN = edt.ISBN
            };
            return View(edtrst);

        }
        [HttpPost]
        public IActionResult Edit(Book b)
        {
            var edt = new Book()
            {
                id=b.id,
                title = b.title,
                author = b.author,
                ISBN = b.ISBN
            };
            _db.Books.Update(edt);
            _db.SaveChanges();
            return RedirectToAction("Index_Book");
        }
    }
}
