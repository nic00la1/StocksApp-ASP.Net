namespace StocksApp_ASP.Net.Services;

public class MyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public void method()
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
        }
    }
}
