using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.PizzaFolderTest;
using NewMenuPizza.Services;
using System.ComponentModel.DataAnnotations;

namespace NewMenuPizza.Pages.Menu
{
    public class NyPizzaModel : PageModel
    { 
        private PizzaRepository _pizzarepo;

        public NyPizzaModel(PizzaRepository pizzarepo)
        {
            _pizzarepo = pizzarepo;
        }

        [BindProperty]
        [Required(ErrorMessage ="Pizzanavn mangler")]
        [StringLength(20, MinimumLength = 5,ErrorMessage ="Der skal være min. 5 tegn")]
        public string NyPizzaNavn { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Pris mangler")]
        public int NyPris { get; set; }

        [BindProperty]
        public int NytNummer { get; set; }
       
        
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Pizza nyPizza = new Pizza(NyPizzaNavn, NyPris, NytNummer);
           
            _pizzarepo.Tilføj(nyPizza);

            return RedirectToPage("/Menu/Index");
        }
    }
}
