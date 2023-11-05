using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.DrikkevarerFolder;
using NewMenuPizza.Services;
using NewMenuPizza.PizzaFolderTest;

namespace NewMenuPizza.Pages.Menu;

public class Index : PageModel
{
    /*
     * Instans felter
     */
    private DrikkevarerRepository _drikkvarerRepo;
    public List<Pizza> Pizzas { get; set; }
    
    /*
     * Dependency Injection
     */
    public Index(DrikkevarerRepository repository)
    {
        _drikkvarerRepo = repository;
    }
    
    /*
     * Property list
     */
    public List<Drikkevarer> Drikkevarers { get; set; }
    
    public void OnGet()
    {
        PizzaRepository pizzarepo = new PizzaRepository(true);

        Drikkevarers = _drikkvarerRepo.HentAlleDrikkevarer();
        Pizzas = pizzarepo.HentAllePizza();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("NyPizza");

    }
}