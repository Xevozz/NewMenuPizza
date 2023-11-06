using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using NewMenuPizza.Kunder;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewMenuPizza.Pages.Kunder
{
    //opretter class til ny kunde razorpage
    public class NyKundeModel : PageModel
    {
        public KundeRepository _repo;

        public NyKundeModel(KundeRepository repo)
        {
            _repo = repo;
        }
        
        //Tilføjer ny kunde til katalog.
        [BindProperty]
        public int NytKundeNummer { get; set; }

        //Fejl visning ved oprettelse af bruger- uden navn angivet.
        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NytKundeNavn { get; set; }
        
        [BindProperty]
        public string NytKundetlf { get; set; }


        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if ( !ModelState.IsValid)
            {
                return Page();
            }
            Kunde nyKunde = new Kunde(NytKundeNavn, NytKundeNummer, NytKundetlf);

            KundeRepository repo = new KundeRepository(true);
            _repo.Tilføj(nyKunde);

            return RedirectToPage("Index");
        }
    }
}