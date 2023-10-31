namespace NewMenuPizza.Kunder;

//instans
//properties (navn, adresse, tlf) 
//kontruktør (liste) (public Kunde (int nr, string navn, string tlf)
//ToString - til dictionary

public class Kunde
{
    //instantfelt
    private string _navn;
    private string _adresse;
    private string _tlf;
    
    //properties

    public string _Navn
    {
        get { return _navn; }
        set { _navn = value;  }
    }
    
    public string _Adresse
    {
        get { return _adresse; }
        set { _adresse = value;  }
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
        _adresse = "";
        _tlf = "";
    }

    public Kunde(string navn, string adresse, string tlf)
    {
        _navn = navn;
        _adresse = adresse;
        _tlf = tlf;
    }

    public override string ToString()
    {
        return $"{nameof(_navn)}: {_navn}, {nameof(_adresse)}: {_adresse}, {nameof(_tlf)}: {_tlf}";
    }
}