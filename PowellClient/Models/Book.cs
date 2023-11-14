using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PowellClient.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Summary { get; set; }

    public static List<Book> GetBooks()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());

      return bookList;
    }

     public static Book GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Book book = JsonConvert.DeserializeObject<Book>(jsonResponse.ToString());

      return book;
    }

    public static void Post(Book book)
    {
      string jsonBook = JsonConvert.SerializeObject(book);
      ApiHelper.Post(jsonBook);
    }

    public static void Put(Book book)
    {
      string jsonBook = JsonConvert.SerializeObject(book);
      ApiHelper.Put(book.BookId, jsonBook);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}