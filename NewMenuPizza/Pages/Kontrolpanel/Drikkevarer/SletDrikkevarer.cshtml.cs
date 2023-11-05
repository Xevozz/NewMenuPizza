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
        
        /*
         * Property
         */
        public SletDrikkevarer(DrikkevarerRepository repository)
        {
            _drikkevarerRepo = repository;
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

            _drikkevarerRepo.Slet(SletDrikkevarerNummer);

            return RedirectToPage("../Index");
        }
    }
}

