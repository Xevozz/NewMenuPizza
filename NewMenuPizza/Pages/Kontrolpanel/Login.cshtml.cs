using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewMenuPizza.Pages.Kontrolpanel
{
    public class Login : PageModel
    {
    
        [BindProperty]
        public string Brugernavn { get; set; }
    
        [BindProperty]
        public string Kodeord { get; set; }
    
        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {
            if (Brugernavn == "denbedstegruppe" && Kodeord == "test123")
            {
                return RedirectToPage("Index");            
            }
        
            return Page();   
        }
    }
}

