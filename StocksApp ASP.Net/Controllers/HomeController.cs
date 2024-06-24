using Microsoft.AspNetCore.Mvc;

namespace StocksApp_ASP.Net.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}
