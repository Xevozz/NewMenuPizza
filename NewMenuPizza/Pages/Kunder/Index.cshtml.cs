using NewMenuPizza.Model;
using NewMenuPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Kunder;

namespace NewMenuPizza.Pages.Kunder
{
    public class IndexModel : PageModel
    {
        // instans af kunde repository
        public KundeRepository _repo;

        // Dependency Injection
        public IndexModel(KundeRepository repository)
        {
            _repo = repository;
        }





        // property til View
        public List<Kunde> Kunder { get;  set; }

        public void OnGet()
        {

            KundeRepository repo = new KundeRepository(true);

            Kunder = _repo.HentAlleKunder();

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("NyKunde");
        }
    }
}