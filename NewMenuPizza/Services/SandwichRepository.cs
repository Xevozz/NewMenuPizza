using NewMenuPizza.SandwichFolder;
using System.Diagnostics.Eventing.Reader;

namespace NewMenuPizza.Services
{
    public class Sandwichrepository
    {
        // instans felter

        public Dictionary<int, Sandwich> _sandwichrepo;

        // Properties
        public Dictionary<int, Sandwich> Sandwichrepo
        {
            get { return _sandwichrepo; }
            set { _sandwichrepo = value; }
        }

        // Default Constructor
        public Sandwichrepository(bool mockdata = false)
        {
            _sandwichrepo = new Dictionary<int, Sandwich>();
            if (mockdata)
            {
                _sandwichrepo.Clear();
                _sandwichrepo.Add(SidsteNummer(), new Sandwich("Kylling/bacon", 85, SidsteNummer()));
                _sandwichrepo.Add(SidsteNummer(), new Sandwich("Okesød", 85, SidsteNummer()));

            }
        }

        public List<Sandwich> HentAlleSandwich()
        {
            return _sandwichrepo.Values.ToList();
        }


        // Metoder

        // Tilføj Pizzanummer

        public void Tilføj(Sandwich pizza)
        {
            _sandwichrepo.Add(pizza.Nummer, pizza);
        }


        // Fjern Pizzanummer
        public Sandwich Fjern(int nummer)
        {
            Sandwich IngenPizza = new Sandwich();
            if (_sandwichrepo.ContainsKey(nummer))
            {
                _sandwichrepo.Remove(nummer);

                return IngenPizza;

            }
            else
            {
                throw new Exception("Pizzanummer findes ikke");
            }
        }

        // Hent pizzanummer

        public Sandwich HentPizzaNummer(int nummer)
        {
            if (_sandwichrepo.ContainsKey(nummer))
            {
                return _sandwichrepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("Pizzanummer findes ikke");
            }
        }

        // Opdater Pizzanummer

        public void OpdaterPizzaNummer(int nummer, Sandwich opdateretPizza)
        {
            if (_sandwichrepo.ContainsKey(nummer))
            {
                Sandwich eksisterendePizza = _sandwichrepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("Pizzanummer findes ikke");
            }
        }

        public int SidsteNummer()
        {
            if (!_sandwichrepo.Any())
            {
                return 1;
            }
            else
            {
                int sidstenummer = _sandwichrepo.Keys.Max() + 1;
                return sidstenummer;
            }
        }
    }
}

