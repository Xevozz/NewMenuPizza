using NewMenuPizza.PizzaFolder;

namespace NewMenuPizza.Pizza
{
    public class PizzaRepository
    {
        // instans felter

        public Dictionary<int, Pizza> _pizzarepo;

        // Properties
        public Dictionary<int, Pizza> Pizzarepo
        {
          get { return _pizzarepo; }
          set { _pizzarepo = value; }
        }

        // Default Constructor
        public PizzaRepository()
        {
            _pizzarepo = new Dictionary<int, Pizza>();
        }

        public List<Pizza> HentAllePizza()
        {
            return _pizzarepo.Values.ToList();
        }


        // Metoder

        // Tilføj Pizzanummer

        public void Tilføj(Pizza pizza)
        {
            _pizzarepo.Add(pizza.Nummer, pizza);
        }


        // Fjern Pizzanummer
        public Pizza Fjern(int nummer)
        {
            Pizza IngenPizza = new Pizza();
            if (_pizzarepo.ContainsKey(nummer))
            {
                _pizzarepo.Remove(nummer);

                return IngenPizza;
                
            }
            else
            {
                throw new Exception("Pizzanummer findes ikke");
            }
        }

        // Hent pizzanummer
        
        public Pizza HentPizzaNummer(int nummer)
        {
            if (_pizzarepo.ContainsKey(nummer))
            {
                return _pizzarepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("Pizzanummer findes ikke");
            }
        }

        // Opdater Pizzanummer

        public void OpdaterPizzaNummer(int nummer, Pizza opdateretPizza)
        {
            if (_pizzarepo.ContainsKey(nummer))
            {
                Pizza eksisterendePizza = _pizzarepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("Pizzanummer findes ikke");
            }
        }

        
    }
}
