using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testingCRUDSearch.Models;

namespace testingCRUDSearch.Controllers
{
    public class BookController : Controller
    {
        BookModel bookModel = new BookModel();
        // GET: Book
        public ActionResult Index()
        {
            return View(bookModel.GetBooks());
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            bookModel.Insert(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bookModel.GetBook(id));
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            bookModel.Update(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(bookModel.Delete(id));
        }

        [HttpPost,ActionName("Delete")]
        
        public ActionResult ConfirmDelete(int id)
        {
            
            bookModel.Delete(id);
            return RedirectToAction("Index");
        }


    }
}