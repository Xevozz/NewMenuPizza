using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using NewMenuPizza.DrikkevarerFolder;

namespace NewMenuPizza.Pages.Kontrolpanel.Drikkevarer
{
    public class NyDrikkevarer : PageModel
    {
        /*
         * Instans fields
         */
        private MenuItemRepository _menuItemRepo;
        private DrikkevarerRepository _drikkevarerRepo;
        
        /*
         * property
         */
        public NyDrikkevarer(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }
        
        [BindProperty]
        public string NytDrikkevarerNavn { get; set; }
        
        [BindProperty]
        public double NytDrikkevarerPris { get; set; }
    
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DrikkevarerFolder.Drikkevarer nyDrikkevarer = new DrikkevarerFolder.Drikkevarer(_menuItemRepo.HentSidsteNummer(),NytDrikkevarerNavn, NytDrikkevarerPris);

            //DrikkevarerRepository repo = new DrikkevarerRepository(true);
            _menuItemRepo.Tilføj(nyDrikkevarer);

            return RedirectToPage("../Index");
        }
    }
}

