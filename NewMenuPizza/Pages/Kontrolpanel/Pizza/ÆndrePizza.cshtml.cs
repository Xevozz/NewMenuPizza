using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using NewMenuPizza.PizzaFolderTest;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public string ÆndrePizzaNavn { get; set; }


        [BindProperty]
        public int ÆndrePizzaPris { get; set; }

        [BindProperty]
        public int ÆndrePizzaNummer { get; set; }

        [BindProperty]
        public bool NummerDeaktiveret {  get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPostLoadPizzaer()
        {
            try
            {
                var pizza = _pizzarepo.HentPizzaNummer(ÆndrePizzaNummer);
                ÆndrePizzaNavn = pizza.Navn;
                ÆndrePizzaPris = pizza.Pris;
                NummerDeaktiveret = true;
            }
            catch (KeyNotFoundException)
            {
                NummerDeaktiveret = false;
            }
            return Page();
        }

        public IActionResult OnPostChangePizzaer()
        {
            try
            {
                _pizzarepo.OpdaterPizzaNummer(ÆndrePizzaNummer,
                    new PizzaFolderTest.Pizza(ÆndrePizzaNavn, ÆndrePizzaNummer, ÆndrePizzaPris));

                return RedirectToPage("/Menu/Index");
            }
            catch (KeyNotFoundException)
            {
                return Page();
            }
        }

    }
}
