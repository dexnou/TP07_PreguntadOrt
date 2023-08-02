using Microsoft.AspNetCore.Mvc;

namespace TP07_PreguntadOrt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
