using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using NewMenuPizza.PizzaFolderTest;
using System.ComponentModel.DataAnnotations;

namespace NewMenuPizza.Pages.Kontrolpanel.Pizza
{
    public class ÆndrePizzaModel : PageModel
    {
        private PizzaRepository _pizzarepo;

        public ÆndrePizzaModel(PizzaRepository pizzarepo)
        {
            _pizzarepo = pizzarepo;
        }

        [BindProperty]
        [Required(ErrorMessage = "Pizzanavn mangler")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Der skal være min. 5 tegn")]
        public string NyPizzaNavn { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Pris mangler")]
        public int NyPris { get; set; }

        [BindProperty]
        public int NytNummer { get; set; }


        public void OnGet(int nummer)
        {

            PizzaFolderTest.Pizza pizza = _pizzarepo.HentPizzaNummer(nummer);

            
            NyPizzaNavn = pizza.Navn;
            NyPris = pizza.Pris;
            NytNummer = pizza.Nummer;
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
