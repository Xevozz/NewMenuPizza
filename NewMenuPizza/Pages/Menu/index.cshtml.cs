using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.DrikkevarerFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Menu;

public class index : PageModel
{
    public List<Drikkevarer> Drikkevarers { get; set; }
    
    public void OnGet()
    {
        DrikkevarerRepository repo = new DrikkevarerRepository(true);

        Drikkevarers = repo.HentDrikkevarer();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Drikkevarere");
    }
}