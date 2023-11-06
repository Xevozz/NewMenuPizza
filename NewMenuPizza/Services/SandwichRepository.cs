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

        public Sandwich Slet(int nummer)
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

        public Sandwich Opdater(int nummer, Sandwich opdateretDrikkevarer)
        {
         if (_sandwichRepo.ContainsKey(nummer))
         {
          _sandwichRepo[nummer].Navn = opdateretDrikkevarer.Navn;
          _sandwichRepo[nummer].Pris = opdateretDrikkevarer.Pris;

          return _sandwichRepo[nummer];
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        public Sandwich HentDrikkevarer(int nummer)
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
        
        public List<Sandwich> HentAlleDrikkevarer()
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