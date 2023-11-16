using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Pages.Kontrolpanel.Drikkevarer;
using NewMenuPizza.SandwichFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Menu
{
    public class NySandwichModel : PageModel
    { 
        /*
         * Instans
         */
        private MenuItemRepository _menuItemReop;
        
        /*
         * Property
         */
        public NySandwichModel(MenuItemRepository repository)
        {
            _menuItemReop = repository;
        }
        
        [BindProperty]
        public string NytSandwichNavn { get; set; }
        
        [BindProperty]
        public double NytSandwichPris { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Sandwich nySandwich = new Sandwich(_menuItemReop.HentSidsteNummer(), NytSandwichNavn, NytSandwichPris);

            _menuItemReop.Tilføj(nySandwich);

            return RedirectToPage("../Index");
        }
    }
}