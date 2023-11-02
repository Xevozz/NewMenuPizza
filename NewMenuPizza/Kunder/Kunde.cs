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

    public string _Navn
    {
        get { return _navn; }
        set { _navn = value;  }
    }
    
    private int _KundeNummer
    {
        get { return _kundenummer; }
        set { _kundenummer = value;  }
    }
    
    public string _Tlf
    {
        get { return _tlf; }
        set { _tlf = value;  }
    }
    
    //konstruktør

    public Kunde()
    {
        _navn = "";
        _kundenummer = 0;
        _tlf = "";
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