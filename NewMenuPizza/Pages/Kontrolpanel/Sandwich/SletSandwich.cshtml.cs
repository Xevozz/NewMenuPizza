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
        private MenuItemRepository _menuItemRepo;
        
        /*
         * Property
         */
        public SletSandwichModel(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
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
            
            _menuItemRepo.Slet(SletSandwichNummer);

            return RedirectToPage("../Index");
        }
    }
}