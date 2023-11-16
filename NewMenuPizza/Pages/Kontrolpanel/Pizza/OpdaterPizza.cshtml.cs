using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using KeyNotFoundExecption = System.Collections.Generic.KeyNotFoundException;


namespace NewMenuPizza.Pages.Kontrolpanel.Pizza
{
    public class ÆndrePizzaModel : PageModel
    {
        private MenuItemRepository _menuItemRepo;

        public ÆndrePizzaModel(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }

        [BindProperty]
        public string ÆndrePizzaNavn { get; set; }


        [BindProperty]
        public double ÆndrePizzaPris { get; set; }

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
                var pizza = _menuItemRepo.HentMenuItem(ÆndrePizzaNummer);
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                _menuItemRepo.Opdater(ÆndrePizzaNummer,
                    new PizzaFolderTest.Pizza(ÆndrePizzaNavn, ÆndrePizzaPris, ÆndrePizzaNummer));

                return RedirectToPage("../../Menu/Index");
            }
            catch (KeyNotFoundException)
            {
                return Page();
            }
        }
    }
}
