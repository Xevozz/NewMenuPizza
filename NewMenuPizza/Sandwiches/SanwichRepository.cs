using AspNetCore;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace NewMenuSandwich.Sandwiches
{
    public class SandwichRepository
    {
        // instans felter

        private Dictionary<int, Sandwiches> _sandwichrepo;

        // Properties
        public Dictionary<int, Sandwiches> Sandwichrepo
        {
          get { return _sandwichrepo; }
          set { _sandwichrepo = value; }
        }

        // Default Constructor
        public SandwichRepository()
        {
            _sandwichrepo = new Dictionary<int, Sandwiches>();
        }

        // Metoder

        // Tilføj sandwich nummer

        public void Tilføj(Sandwiches sandwich)
        {
            _sandwichrepo.Add(sandwich.Nummer, sandwich);
        }


        // Fjern sandwich nummer
        public Sandwiches Fjern(int nummer)
        {
            Sandwiches IngenSandwich = new Sandwiches();
            if (_sandwichrepo.ContainsKey(nummer))
            {
                _sandwichrepo.Remove(nummer);

                return IngenSandwich;
                
            }
            else
            {
                throw new Exception("Sandwich nummer findes ikke");
            }
        }

        // Hent sandwich nummer
        
        public Sandwiches HentSandwichNummer(int nummer)
        {
            if (_sandwichrepo.ContainsKey(nummer))
            {
                return _sandwichrepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("sandwich nummer findes ikke");
            }
        }

        // Opdater sandwich nummer

        public void OpdaterSandwichNummer(int nummer, Sandwiches opdateretSandwich)
        {
            if (_sandwichrepo.ContainsKey(nummer))
            {
                Sandwiches eksisterendeSandwich = _sandwichrepo[nummer];
            }
            else
            {
                throw new KeyNotFoundException("sandwich nummer findes ikke");
            }
        }

    }
}
