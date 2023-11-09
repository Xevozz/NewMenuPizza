using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Kontrolpanel.Drikkevarer
{
    public class SletDrikkevarer : PageModel
    {
        /*
         * Instans field
         */
        private DrikkevarerRepository _drikkevarerRepo;
        private MenuItemRepository _menuItemRepo;
        
        /*
         * Property
         */
        public SletDrikkevarer(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }
        
        [BindProperty]
        public int SletDrikkevarerNummer { get; set; }
        
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _menuItemRepo.Slet(SletDrikkevarerNummer);

            return RedirectToPage("../Index");
        }
    }
}

