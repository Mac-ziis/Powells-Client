using System.Threading.Tasks;
using RestSharp;

namespace PowellClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

     public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      // may need to change
      RestRequest request = new RestRequest($"api/books/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

     public static async void Post(string newBook)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      // may need to change
      RestRequest request = new RestRequest($"api/books", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBook);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newBook)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      // may need to change
      RestRequest request = new RestRequest($"api/books/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBook);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/books/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}