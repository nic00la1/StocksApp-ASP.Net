﻿namespace StocksApp_ASP.Net.Services;

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
                RequestUri = new Uri("url"),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponseMessage = await
                httpClient.SendAsync(httpRequestMessage);
        }
    }
}
