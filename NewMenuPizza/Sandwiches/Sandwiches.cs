namespace NewMenuPizza.Sandwiches;

public class Sandwiches
{
    private string _name;
    private double _price;
    private int _number;


    public string Navn
    {
        get { return _name; }
        set { _name = value; }
    }

    public double Pris
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Nummer
    {
        get { return _number; }
        set { _number = value; }
    }


    public Sandwiches()
    {
        _name = "";
        _price = 0;
        _number = 0;
    }

    public Sandwiches(string navn, double pris, int nummer)
    {
        _name = navn;
        _price = pris;
        _number = nummer;

    }

    // toString 
    public override string ToString()
    {
        return $"{{{nameof(Pris)}={Pris.ToString()}}}";
    }

}