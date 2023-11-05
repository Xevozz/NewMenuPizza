using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Kontrolpanel.Pizza
{
    public class SletPizzaModel : PageModel
    {
        private PizzaRepository _pizzarepo;

        public SletPizzaModel(PizzaRepository pizzarepo)
        {
            _pizzarepo = pizzarepo;
        }

        [BindProperty]
        public int SletPizza { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {

            _pizzarepo.Fjern(SletPizza);
            
            return RedirectToPage("Index");

        }
    }
}
