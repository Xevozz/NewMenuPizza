using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMenuPizza.OrdreFolder;
using NewMenuPizza.Services;

namespace NewMenuPizza.Pages.OrdrePages;

public class Index : PageModel
{
    /*
     * Instans
     */
    //private OrdreRepository _ordreRepo;
    private Ordre _ordre;
    public double _samletBeløb;

    /*
     * Dependency Injection
     */
    public Index(Ordre ordre)
    {
        //_ordreRepo = ordreRepository;
        _ordre = ordre;
    }
    
    /*
     * Property
     */
    public List<MenuItem> MenuItems { get; set; }
    
    
    public void OnGet()
    {
        //Ordres = _ordreRepo.HentAlleOrdre();
        MenuItems = _ordre.HentAlleOrdre();
        _samletBeløb = _ordre.SumAfAlleItems();
    }
}