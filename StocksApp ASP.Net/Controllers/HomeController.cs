using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp_ASP.Net.Services;

namespace StocksApp_ASP.Net.Controllers;

public class HomeController : Controller
{
    private readonly FinnhubService _finnhubService;
    private readonly IOptions<TradingOptions> _tradingOptions;

    public HomeController(FinnhubService finnhubService,
                          IOptions<TradingOptions> tradingOptions
    )
    {
        _finnhubService = finnhubService;
        _tradingOptions = tradingOptions;
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        Dictionary<string, object>? responseDictionary =
            await _finnhubService.GetStockPriceQuote(_tradingOptions.Value
                .DeafultStockSymbol);

        return View();
    }
}
