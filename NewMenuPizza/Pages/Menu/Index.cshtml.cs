using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.DrikkevarerFolder;
using NewMenuPizza.PizzaFolderTest;
using NewMenuPizza.SandwichFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Menu;

public class Index : PageModel
{
    /*
     * Instans felter
     */
    private DrikkevarerRepository _drikkvarerRepo;
    private IngrediensRepository _ingrediensrepo;
    private PizzaRepository _pizzarepo;
    private SandwichRepository _sandwichrepo;
    
    /*
     * Dependency Injection
     */
    public Index(DrikkevarerRepository drikkevarerRepo, IngrediensRepository ingrediensRepo)
    {
        _drikkvarerRepo = drikkevarerRepo;
        _ingrediensrepo = ingrediensRepo;
    }
    /*
     * Property list
     */
    public List<Drikkevarer> Drikkevarers { get; set; }
    public List<Pizza> Pizzas { get; set; }
    public List<Sandwich> Sandwiches { get; set; }
    public List<Ingrediens> IngrediensList { get; set; }

    public void OnGet()
    {
        

        Drikkevarers = _drikkvarerRepo.HentAlleDrikkevarer();
        Pizzas = _pizzarepo.HentAllePizza();
        IngrediensList = _ingrediensrepo.HentAlleIngredienser();
        Sandwiches = _sandwichrepo.HentAlleSandwiches();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("");

    }
}