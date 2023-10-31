using System.Collections.Specialized;

namespace NewMenuPizza.Pizza
{
    public class PizzaRepository
    {
        // instans felter

        private Dictionary<int, Pizza> _pizzarepo;

        // Properties
        public Dictionary<int, Pizza> PizzaRepo
        {
          get { return _pizzarepo; }
          set { _pizzarepo = value; }

        }
      
    }
}
