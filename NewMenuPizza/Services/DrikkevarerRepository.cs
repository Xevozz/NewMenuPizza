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

        public DrikkevarerRepository()
        {
         _drikkevarerRepo = new Dictionary<int, Drikkevarer>();
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