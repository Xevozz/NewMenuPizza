using NewMenuPizza.DrikkevarerFolder;

namespace NewMenuPizza;

public class MenuItem
{
    private int _nummer;
    private string _navn;
    private double _pris;

    public int Nummer
    {
        get { return _nummer; }
        set { _nummer = value; }
    }
    
    public string Navn
    {
        get { return _navn; }
        set { _navn = value; }
    }

    public double Pris
    {
        get { return _pris;}
        set { _pris = value; }
    }
    
    /*
     * Constructor
     */

    public MenuItem()
    {
        _nummer = 0;
        _navn = "";
        _pris = 0.0;
    }

    public MenuItem(int nummer, string navn, double pris)
    {
        _nummer = nummer;
        _navn = navn;
        _pris = pris;
    }
    
}