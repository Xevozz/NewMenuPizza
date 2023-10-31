using System.Collections.Specialized;

namespace NewMenuPizza.Pizza
{
    public class PizzaRepository
    {
        // instans felter

        private Dictionary<int, Pizza> _pizzarepository;


        Dictionary<int, Pizza> PizzaRepository
        {
          get { return _pizzarepository; }
          set { _pizzarepository = value; }
        }
    }
}
