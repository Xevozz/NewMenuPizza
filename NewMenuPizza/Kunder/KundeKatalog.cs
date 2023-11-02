namespace NewMenuPizza.Kunder;

public class KundeKatalog
{
    // instans felt
    Dictionary<int, Kunde> _katalog;

    // properties
    public Dictionary<int, Kunde> Katalog
    {
        get { return _katalog; }
        set { _katalog = value; }
    }

    // konstruktør
    public KundeKatalog()
    {
        _katalog = new Dictionary<int, Kunde>();
    }


    
    //metoder
    public Kunde Tilføj(Kunde kunde)
    {
        _katalog.Add(kunde.KundeNummer, kunde);

        return kunde;
    }

    public Kunde Slet(int kundenummer)
    {
        if (_katalog.ContainsKey(kundenummer))
        {
            Kunde slettetKunde = _katalog[kundenummer];
            _katalog.Remove(kundenummer);
            return slettetKunde;
                
        }
        else
        {
            return null;
        }
    }

    public Kunde HentKunde(int kundenummer)
    {
        if (_katalog.ContainsKey(kundenummer))
        {
            return _katalog[kundenummer];

        }
        else
        {
            // opdaget en fejl
            throw new KeyNotFoundException("kundenummer findes ikke");
                


            //return null;
        }
    }


    public Kunde HentKundeUdFraTlf(string tlf)
    {
        Kunde resKunde = null;

        foreach(Kunde k in _katalog.Values)
        {
            if (k.Tlf == tlf)
            {
                return k;
            }
        }

        return resKunde;
    }

    public override string ToString()
    {
        String pænTekst = String.Join(", ", _katalog.Values);

        return $"{{{nameof(Katalog)}={pænTekst}}}";
    }
}

