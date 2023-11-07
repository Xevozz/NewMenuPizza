using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Kontrolpanel.Sandwich
{
    public class SletSandwich : PageModel
    {
        /*
         * Instans field
         */
        private DrikkevarerRepository _sandwichRepo;
        
        /*
         * Property
         */
        public SletSandwich(DrikkevarerRepository repository)
        {
            _sandwichRepo = repository;
        }
        
        [BindProperty]
        public int SletSandwichNummer { get; set; }
        
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _sandwichRepo.Slet(SletSandwichNummer);

            return RedirectToPage("../Index");
        }
    }
}