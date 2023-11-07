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
    private IngrediensRepository _ingrediensrepo;
    private PizzaRepository _pizzarepo;

    /*
     * Dependency Injection
     */
    public Index(DrikkevarerRepository drikkevarerRepo, IngrediensRepository ingrediensRepo, PizzaRepository pizzaRepository)
    {
        _drikkvarerRepo = drikkevarerRepo;
        _ingrediensrepo = ingrediensRepo;
        _pizzarepo = pizzaRepository;
    }
    /*
     * Property list
     */
    public List<Drikkevarer> Drikkevarers { get; set; }

    public List<Pizza> Pizzas { get; set; }

    public List<Ingrediens> IngrediensList { get; set; }

    public void OnGet()
    {
        

        Drikkevarers = _drikkvarerRepo.HentAlleDrikkevarer();
        Pizzas = _pizzarepo.HentAllePizza();
        IngrediensList = _ingrediensrepo.HentAlleIngredienser();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("");

    }
}