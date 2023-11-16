namespace NewMenuPizza.SandwichFolder;

public class Sandwich : MenuItem
{
    //default constructer
    public Sandwich()
    {
    }

    public Sandwich(int nummer, string navn, double pris) : base(nummer, navn, pris) 
    {
    }
}