using Microsoft.AspNetCore.Mvc;
using StocksApp_ASP.Net.Services;

namespace StocksApp_ASP.Net.Controllers;

public class HomeController : Controller
{
    private readonly MyService _myService;

    public HomeController(MyService myService)
    {
        _myService = myService;
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        await _myService.method();

        return View();
    }
}
