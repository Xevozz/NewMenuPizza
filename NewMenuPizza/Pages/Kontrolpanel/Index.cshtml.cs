using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Kunder;

namespace NewMenuPizza.Pages.Kontrolpanel;

public class Index : PageModel
{
    public List<Kunde> kunders { get;  set; }

    public void OnGet()
    {
        KundeRepository repo = new KundeRepository(true);
            
        kunders = repo.HentAlleKunder();

    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Kunde");
    }
}