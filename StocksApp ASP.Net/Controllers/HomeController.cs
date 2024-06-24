using Microsoft.AspNetCore.Mvc;
using StocksApp_ASP.Net.Services;

namespace StocksApp_ASP.Net.Controllers;

public class HomeController : Controller
{
    private readonly FinnhubService _finnhubService;

    public HomeController(FinnhubService finnhubService)
    {
        _finnhubService = finnhubService;
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        Dictionary<string, object>? responseDictionary =
            await _finnhubService.GetStockPriceQuote("MSFT");

        return View();
    }
}
