using Microsoft.AspNetCore.Mvc;

namespace NewMenuPizza.Kunder;

public class OpretKunde : PageModel
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}