using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Kunder;

namespace NewMenuPizza.Pages.Shared;

public class Kunde : PageModel
{
    public class IndexModel : PageModel
    {
        // instans af kunde repository
        private KundeRepository _repo;

        // Dependency Injection
        public IndexModel(KundeRepository repository)
        {
            _repo = repository;
        }

        // property til View'et
        public List<Kunde> Kunder { get;  set; }

        public void OnGet()
        {
            KundeRepository repo = new KundeRepository(true);

            Kunde = _repo.HentAlleKunder();

        }

        public I IActionResult OnPost()
        {
            return RedirectToPage("Kunde");
        }
    }
}