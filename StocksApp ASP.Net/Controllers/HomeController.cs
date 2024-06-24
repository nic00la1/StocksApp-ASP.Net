using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp_ASP.Net.Models;
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
        if (_tradingOptions.Value.DeafultStockSymbol == null)
            _tradingOptions.Value.DeafultStockSymbol = "MSFT";

        Dictionary<string, object>? responseDictionary =
            await _finnhubService.GetStockPriceQuote(_tradingOptions.Value
                .DeafultStockSymbol);

        Stock stock = new()
        {
            Symbol = _tradingOptions.Value.DeafultStockSymbol,
            CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString()),
            HighestPrice = Convert.ToDouble(responseDictionary["h"].ToString()),
            LowestPrice = Convert.ToDouble(responseDictionary["l"].ToString()),
            OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString())
        };
        return View(stock);
    }
}
