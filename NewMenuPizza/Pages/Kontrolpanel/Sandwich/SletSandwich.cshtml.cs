using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Kontrolpanel.Sandwich
{
    public class SletSandwichModel : PageModel
    {
        /*
         * Instans field
         */
        private SandwichRepository _sandwichrepo;
        
        /*
         * Property
         */
        public SletSandwichModel(SandwichRepository repository)
        {
            _sandwichrepo = repository;
        }
        
        [BindProperty]
        public int SletSandwich { get; set; }
        
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            _sandwichrepo.fjern(SletSandwich);

            return RedirectToPage("../Index");
        }
    }
}