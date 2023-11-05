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

    public List<Ingrediens> IngrediensList { get; set; }

    public void OnGet()
    {
        PizzaRepository pizzarepo = new PizzaRepository(true);

        Drikkevarers = _drikkvarerRepo.HentAlleDrikkevarer();
        Pizzas = pizzarepo.HentAllePizza();
        IngrediensList = _ingrediensrepo.HentAlleIngredienser();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("");

    }
}