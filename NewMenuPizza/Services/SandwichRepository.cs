using NewMenuPizza.SandwichFolder;

namespace NewMenuPizza.Services
{
    public class SandwichRepository
    {
        /*
         * Instance field
         */
        
        private Dictionary<int, Sandwich> _sandwichRepo;

        /*
         * Properties
         */

        public Dictionary<int, Sandwich> SandwichRepo
        {
         get { return _sandwichRepo; }
         set { _sandwichRepo = value; }
        }

        /*
         * Constructor
         */

        public SandwichRepository(bool mockData = false)
        {
         _sandwichRepo = new Dictionary<int, Sandwich>();

         if (mockData)
         {
          _sandwichRepo.Clear();
          
          _sandwichRepo.Add(GetSidsteNummer(), new Sandwich("Kylling", 0, GetSidsteNummer()));
          _sandwichRepo.Add(GetSidsteNummer(), new Sandwich("Bacon", 0, GetSidsteNummer()));
          _sandwichRepo.Add(GetSidsteNummer(), new Sandwich("Oksekød>", 0, GetSidsteNummer()));
          _sandwichRepo.Add(GetSidsteNummer(), new Sandwich("Haj", 0, GetSidsteNummer()));
         }
        }
        
        /*
         * Methods
         */
        
        

        public Sandwich Tilføj(Sandwich drikkevarer)
        {
          _sandwichRepo.Add(drikkevarer.Nummer, drikkevarer);

          return drikkevarer;
        }

        public Sandwich fjern(int nummer)
        {
         if (_sandwichRepo.ContainsKey(nummer))
         {
          Sandwich slettetDrikkevarer = _sandwichRepo[nummer];
          _sandwichRepo.Remove(nummer);
          return slettetDrikkevarer;
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        public Sandwich update(int nummer, Sandwich opdateretSandwich)
        {
         if (_sandwichRepo.ContainsKey(nummer))
         {
          _sandwichRepo[nummer].Navn = opdateretSandwich.Navn;
          _sandwichRepo[nummer].Pris = opdateretSandwich.Pris;

          return _sandwichRepo[nummer];
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        public Sandwich HentSandwich(int nummer)
        { 
         if (_sandwichRepo.ContainsKey(nummer))
         {
          return _sandwichRepo[nummer];
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }
        
        public List<Sandwich> HentAlleSandwiches()
        {
         return _sandwichRepo.Values.ToList();
        }

        public int GetSidsteNummer()
        {
         if (!_sandwichRepo.Any())
         {
          return 1;
         }
         else
         {
          int sidsteNummer = _sandwichRepo.Keys.Max();
          return sidsteNummer + 1;
         }
        }
    }
}