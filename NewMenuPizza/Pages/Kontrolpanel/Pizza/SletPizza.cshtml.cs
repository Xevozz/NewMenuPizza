using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.Services;
using System.ComponentModel.DataAnnotations;

namespace NewMenuPizza.Pages.Kontrolpanel.Pizza
{
    public class SletPizzaModel : PageModel
    {
        private MenuItemRepository _menuItemRepo;

        public SletPizzaModel(MenuItemRepository repository)
        {
            _menuItemRepo = repository;
        }

        [BindProperty]
        public int SletPizza { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {

            _menuItemRepo.Slet(SletPizza);

            return RedirectToPage("../Index"); 

        }
    }
}
