using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Pages.Kontrolpanel.Drikkevarer;
using NewMenuPizza.PizzaFolderTest;
using NewMenuPizza.Services;
using System.ComponentModel.DataAnnotations;

namespace NewMenuPizza.Pages.Menu
{
    public class NyPizzaModel : PageModel
    {
        private MenuItemRepository _menuItemRepo;

        public NyPizzaModel(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
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

            _menuItemRepo.Tilføj(nyPizza);

            return RedirectToPage("../Index");
        }
    }
}
