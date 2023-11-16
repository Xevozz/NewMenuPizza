using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Kontrolpanel.Sandwich
{
    public class OpdaterSandwich : PageModel
    {
        /*
         * Instans
         */
        private MenuItemRepository _menuItemRepo;
        
        /*
         * Property
         */
        public OpdaterSandwich(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }
        
        [BindProperty] 
        public int ÆndreSandwichNummer { get; set; }
        
        [BindProperty]
        public string ÆndreSandwichNavn { get; set; }
        
        [BindProperty]
        public double ÆndreSandwichPris { get; set; }
        
        [BindProperty]
        public bool NummerDeaktiveret { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPostLoadSandwich()
        {
            try
            {
                var sandwich = _menuItemRepo.HentMenuItem(ÆndreSandwichNummer);
                ÆndreSandwichNavn = sandwich.Navn;
                ÆndreSandwichPris = sandwich.Pris;
                NummerDeaktiveret = true;
            }
            catch (KeyNotFoundException)
            {
                ModelState.AddModelError("", "Sandwichen med det angivne nummer blev ikke fundet");
                NummerDeaktiveret = false;
            }
            
            return Page();
        }

        public IActionResult OnPostChangeSandwich()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _menuItemRepo.Opdater(ÆndreSandwichNummer,
                    new SandwichFolder.Sandwich(ÆndreSandwichNummer, ÆndreSandwichNavn, ÆndreSandwichPris));

                return RedirectToPage("../../Menu/Index");
            }
            catch (KeyNotFoundException)
            {
                ModelState.AddModelError("", "Sandwichen kunne ikke opdateres");
                return Page();
            }
        }
    }
}

