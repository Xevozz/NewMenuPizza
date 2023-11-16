using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace NewMenuPizza.Pages.Kontrolpanel.Drikkevarer
{
    public class OpdaterDrikkevarer : PageModel
    {
        /*
         * Instans Field
         */
        
        private MenuItemRepository _menuItemRepo;
        
        /*
         * Property 
         */
        public OpdaterDrikkevarer(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }
        
        [BindProperty] 
        public int ÆndreDrikkevarerNummer { get; set; }
        
        [BindProperty]
        public string ÆndreDrikkevarerNavn { get; set; }
        
        [BindProperty]
        public double ÆndreDrikkevarerPris { get; set; }
        
        [BindProperty]
        public bool NummerDeaktiveret { get; set; }
        
        
        public void OnGet()
        {
        }

        public IActionResult OnPostLoadDrikkevare()
        {
            try
            {
                var drikkevarer = _menuItemRepo.HentMenuItem(ÆndreDrikkevarerNummer);
                ÆndreDrikkevarerNavn = drikkevarer.Navn;
                ÆndreDrikkevarerPris = drikkevarer.Pris;
                NummerDeaktiveret = true;
            }
            catch(KeyNotFoundException)
            {
                ModelState.AddModelError("", "Drikkevaren med det angivne nummer blev ikke fundet.");
                NummerDeaktiveret = false;
            }

            return Page();
        }

        public IActionResult OnPostChangeDrikkevare()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _menuItemRepo.Opdater(ÆndreDrikkevarerNummer,
                    new DrikkevarerFolder.Drikkevarer(ÆndreDrikkevarerNummer, ÆndreDrikkevarerNavn,
                        ÆndreDrikkevarerPris));

                return RedirectToPage("../../Menu/Index");
            }
            catch(KeyNotFoundException)
            {
                ModelState.AddModelError("", "Drikkevaren kunne ikke opdateres, da den ikke findes.");
                return Page();
            }
        }
    }
}

