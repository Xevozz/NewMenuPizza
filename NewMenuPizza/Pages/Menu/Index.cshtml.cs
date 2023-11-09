using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.OrdreFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Menu;

public class Index : PageModel
{
    /*
     * Instans felter
     */
    private IngrediensRepository _ingrediensrepo;
    private MenuItemRepository _menuItemRepo;
    private Ordre _ordre;
    
    /*
     * Dependency Injection
     */
    public Index(MenuItemRepository menuItemRepository, Ordre ordre)
    {
        _menuItemRepo = menuItemRepository;
        _ordre = ordre;
    }
    /*
     * Property list
     */
    public List<MenuItem> MenuItems { get; set; }

    public void OnGet()
    {
        MenuItems = _menuItemRepo.HentAlleMenuItems();
    }
    
    public IActionResult OnPostTilføjTilKurv(int itemId)
    {
        var item = _menuItemRepo.HentMenuItem(itemId);
        
        TilføjItemTilKurv(item);

        return RedirectToPage();
    }

    public void TilføjItemTilKurv(MenuItem item)
    {
        _ordre.TilføjMenuItem(item);
    }

    public IActionResult OnPostGåTilKurv()
    {
        //_ordreRepo.TilføjOrdre(1, _ordre);

        return RedirectToPage("../OrdrePages/Index");
    }
    
    public IActionResult OnPost()
    {
        return RedirectToPage("");

    }
}