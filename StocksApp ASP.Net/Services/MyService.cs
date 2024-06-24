namespace StocksApp_ASP.Net.Services;

public class MyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task method()
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage httpRequestMessage = new()
            {
                RequestUri =
                    new Uri(
                        "https://finnhub.io/api/v1/quote?symbol=AAPL&token=cpsk8a9r01qkode1lnr0cpsk8a9r01qkode1lnrg"),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponseMessage = await
                httpClient.SendAsync(httpRequestMessage);

            Stream stream = httpResponseMessage.Content.ReadAsStream();

            StreamReader streamReader = new(stream);

            string response = streamReader.ReadToEnd();
        }
    }
}
