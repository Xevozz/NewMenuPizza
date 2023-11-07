using NewMenuPizza.PizzaFolderTest;
using System.Diagnostics.Eventing.Reader;

namespace NewMenuPizza.Services
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
        public PizzaRepository(bool mockdata = false)
        {
            _pizzarepo = new Dictionary<int, Pizza>();
            if (mockdata)
            {
                _pizzarepo.Clear();
                _pizzarepo.Add(SidsteNummer(), new Pizza("Hawaii", 85, SidsteNummer()));
                _pizzarepo.Add(SidsteNummer(), new Pizza("Pepperoni", 85, SidsteNummer()));
                _pizzarepo.Add(SidsteNummer(), new Pizza("Napoli", 75, SidsteNummer()));

            }
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
        public void Fjern(int nummer)
        {
            if (_pizzarepo.ContainsKey(nummer))
            {
                _pizzarepo.Remove(nummer);
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

        public int SidsteNummer()
        {
            if (!_pizzarepo.Any())
            {
                return 1;
            }
            else
            {
                int sidstenummer = _pizzarepo.Keys.Max() + 1;
                return sidstenummer;
            }
        }

    }
}
