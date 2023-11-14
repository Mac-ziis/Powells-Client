using Microsoft.AspNetCore.Mvc;
using PowellClient.Models;

namespace PowellClient.Controllers;

public class BooksController : Controller
{
  public IActionResult Index()
  {
    List<Book> books = Book.GetBooks();
    return View(books);
  }

  public IActionResult DONTCLICK()
  {
    return View();
  }

  public IActionResult Details(int id)
  {
    Book book = Book.GetDetails(id);
    return View(book);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Book book)
  {
    Book.Post(book);
    return RedirectToAction("Index");
  }

   public ActionResult Edit(int id)
  {
    Book book = Book.GetDetails(id);
    return View(book);
  }

  [HttpPost]
  public ActionResult Edit(Book book)
  {
    Book.Put(book);
    return RedirectToAction("Details", new { id = book.BookId});
  }

  public ActionResult Delete(int id)
  {
    Book book = Book.GetDetails(id);
    return View(book);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Book.Delete(id);
    return RedirectToAction("Index");
  }
}