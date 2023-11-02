using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.DrikkevarerFolder;
using NewMenuPizza.Services;
using NewMenuPizza.PizzaFolder;

namespace NewMenuPizza.Pages.Menu;

public class index : PageModel
{
    public List<Drikkevarer> Drikkevarers { get; set; }
    public List<Pizza> Pizzas { get; set; }
    
    public void OnGet()
    {
        DrikkevarerRepository repo = new DrikkevarerRepository(true);
        PizzaRepository pizzarepo = new PizzaRepository(true);

        Drikkevarers = repo.HentDrikkevarer();
        Pizzas = pizzarepo.HentAllePizza();
    }

    public Iactionresult OnPost()
    {
        return RedirectToPage("Drikkevarere");
    }
}