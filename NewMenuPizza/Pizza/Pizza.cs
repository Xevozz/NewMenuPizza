namespace NewMenuPizza.Pizza;

public class Pizza
{
    // instans felter

    private string _navn;
    private int _pris;
    private int _pizzanummer;

    // properties

    private string Navn
    {
        get { return _navn; }
        set { _navn = value; }
    }

    public int Pris
    {
        get { return _pris; }
        set { _pris = value; }
    }

    private int Pizzanummer
    {
        get { return _pizzanummer; }
        set { _pizzanummer = value; }
    }

    //  Default Constructor

    public Pizza()
    {
        _navn = "";
        _pris = 0;
        _pizzanummer = 0;
    }

    public Pizza(string navn, int pris, int pizzanummer)
    {
        _navn = navn;
        _pris = pris;
        _pris = pizzanummer;

    }

    // toString 
    public override string ToString()
    {
        return $"{{{nameof(Pris)}={Pris.ToString()}}}";
    }

 }