namespace NewMenuPizza;

public class MenuItem
{
    public MenuItem()
    {
        Nummer = 0;
        Navn = string.Empty;
        Pris = 0.0;
    }

    public MenuItem(int nummer, string navn, double pris)
    {
        Nummer = nummer;
        Navn = navn;
        Pris = pris;
    }

    public int Nummer { get; set; }

    public string Navn { get; set; }

    public double Pris { get; set; }
}