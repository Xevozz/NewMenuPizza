using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using NewMenuPizza.PizzaFolder;

namespace NewMenuPizza.Pages.Pizza;

public class PizzaModel : PageModel
{
    public List<Pizza> pizzas { get; set; };


    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
    }
}
