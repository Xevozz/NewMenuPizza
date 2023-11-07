namespace NewMenuPizza.SandwichFolder;

public class Sandwich
{
    private string _navn;
    private double _pris;
    private int _nummer;


    public string Navn
    {
        get { return _navn; }
        set { _navn = value; }
    }

    public double Pris
    {
        get { return _pris; }
        set { _pris = value; }
    }

    public int Nummer
    {
        get { return _nummer; }
        set { _nummer = value; }
    }

    public Sandwich()
    {
        _navn = "";
        _pris = 0;
        _nummer = 0;
    }

    public Sandwich(string navn, double pris, int nummer)
    {
        _navn = navn;
        _pris = pris;
        _nummer = nummer;

    }

    // toString 
    public override string ToString()
    {
        return $"{nameof(_navn)}: {_navn}, {nameof(_pris)}: {_pris}, {nameof(_nummer)}: {_nummer}";
    }
}