using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.SandwichFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.Menu
{
    public class NySandwichModel : PageModel
    { 
        private SandwichRepository _sandwichrepo;

        public NySandwichModel(SandwichRepository sandwichrepo)
        {
            _sandwichrepo = sandwichrepo;
        }

        [BindProperty]
        public string NySandwich { get; set; }

        [BindProperty]
        public int NyPris { get; set; }

        [BindProperty]
        public int NytNummer { get; set; }
       
        
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            Sandwich nySandwich = new (NySandwich, NyPris, NytNummer);
           
            _sandwichrepo.Add(nySandwich);
        }
    }
}