using NewMenuPizza.DrikkevarerFolder;

namespace NewMenuPizza.Services
{
    public class DrikkevarerRepository
    {
        /*
         * Instance field
         */
        
        private Dictionary<int, Drikkevarer> _drikkevarerRepo;

        /*
         * Properties
         */

        public Dictionary<int, Drikkevarer> DrikkevarerRepo
        {
         get { return _drikkevarerRepo; }
         set { _drikkevarerRepo = value; }
        }

        /*
         * Constructor
         */

        public DrikkevarerRepository(bool mockData = false)
        {
         _drikkevarerRepo = new Dictionary<int, Drikkevarer>();

         if (mockData)
         {
          _drikkevarerRepo.Clear();
          
          _drikkevarerRepo.Add(1, new Drikkevarer(1, "Pepsi", 25.0));
          _drikkevarerRepo.Add(2, new Drikkevarer(2, "Pepsi Max", 25.0));
          _drikkevarerRepo.Add(3, new Drikkevarer(3, "Squash", 25.0));
          _drikkevarerRepo.Add(4, new Drikkevarer(4, "Faxe Kondi", 25.0));
         }
        }
        
        /*
         * Methods
         */

        public Drikkevarer Tilføj(Drikkevarer drikkevarer)
        {
          _drikkevarerRepo.Add(drikkevarer.Nummer, drikkevarer);

          return drikkevarer;
        }

        public Drikkevarer Slet(int nummer)
        {
         if (_drikkevarerRepo.ContainsKey(nummer))
         {
          Drikkevarer slettetDrikkevarer = _drikkevarerRepo[nummer];
          _drikkevarerRepo.Remove(nummer);
          return slettetDrikkevarer;
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        /*public Drikkevarer Opdater()
        {
         
        }*/

        public List<Drikkevarer> HentDrikkevarer()
        {
         return _drikkevarerRepo.Values.ToList();
        }
    }
}