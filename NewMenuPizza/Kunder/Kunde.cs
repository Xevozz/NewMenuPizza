using Microsoft.AspNetCore.Mvc;
using NewMenuPizza.Pages;

namespace NewMenuPizza.Kunder;

//instans
//properties (navn, adresse, tlf) 
//kontruktør (liste) (public Kunde (int nr, string navn, string tlf)
//ToString - til dictionary

public class Kunde
{
    //instantfelt
    private string _navn;
    private int _kundenummer;
    private string _tlf;

    //properties

    public string Navn { get; set; }

    public int KundeNummer { get; set; }

    public string Tlf { get; set; }
    //konstruktør

    public Kunde()
    {
        _navn = string.Empty;
        _kundenummer = 0;
        _tlf = string.Empty;
    }

    public Kunde(string navn, int kundenummer, string tlf)
    {
        _navn = navn;
        _kundenummer = kundenummer;
        _tlf = tlf;
    }

    public override string ToString()
    {
        return $"{nameof(_navn)}: {_navn}, {nameof(_kundenummer)}: {_kundenummer}, {nameof(_tlf)}: {_tlf}";
    }
}