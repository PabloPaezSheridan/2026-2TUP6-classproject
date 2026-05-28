using  System.Net.Http;
using Microsoft.Extensions.Http;

namespace Infrastructure.ExternalHandlers;
public class TheOneAPIHandler: ITheOneAPIHandler
{
    public IHttpClientFactory httpClientFactory;
    public HttpClient client;

    private const string factoryName = "theoneapi";
    public TheOneAPIHandler(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient(factoryName);
    }
    public async Task<string> GetBooks()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("book");
        string body = await responseMessage.Content.ReadAsStringAsync();
        return body;
    }

    public async Task<List<string>> GetMovies()
    {
        throw new NotImplementedException();
    }
}