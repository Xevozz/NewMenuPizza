using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.PizzaFolderTest;
using NewMenuPizza.Services;

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
        public string NyPizza { get; set; }

        [BindProperty]
        public int NyPris { get; set; }

        [BindProperty]
        public int NytNummer { get; set; }
       
        
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            Pizza nyPizza = new Pizza(NyPizza, NyPris, NytNummer);
           
            _pizzarepo.Tilføj(nyPizza);
        }
    }
}
