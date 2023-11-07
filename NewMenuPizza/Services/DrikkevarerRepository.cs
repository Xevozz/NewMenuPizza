using System.Text.Json;
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
         _drikkevarerRepo = ReadFromJson();
         /*_drikkevarerRepo = new Dictionary<int, Drikkevarer>();

         if (mockData)
         {
          _drikkevarerRepo.Clear();

          _drikkevarerRepo.Add(GetSidsteNummer(), new Drikkevarer(GetSidsteNummer(), "Pepsi", 25.0));
          _drikkevarerRepo.Add(GetSidsteNummer(), new Drikkevarer(GetSidsteNummer(), "Pepsi Max", 25.0));
          _drikkevarerRepo.Add(GetSidsteNummer(), new Drikkevarer(GetSidsteNummer(), "Squash", 25.0));
          _drikkevarerRepo.Add(GetSidsteNummer(), new Drikkevarer(GetSidsteNummer(), "Faxe Kondi", 25.0));
         }
         */
        }
        
        /*
         * Methods
         */
        
        

        public Drikkevarer Tilføj(Drikkevarer drikkevarer)
        {
          _drikkevarerRepo.Add(drikkevarer.Nummer, drikkevarer);
          WriteToJson();
          return drikkevarer;
        }

        public Drikkevarer Slet(int nummer)
        {
         if (_drikkevarerRepo.ContainsKey(nummer))
         {
          Drikkevarer slettetDrikkevarer = _drikkevarerRepo[nummer];
          _drikkevarerRepo.Remove(nummer);
          WriteToJson();
          return slettetDrikkevarer;
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        public void Opdater(int nummer, Drikkevarer opdateretDrikkevarer)
        {
         if (_drikkevarerRepo.ContainsKey(nummer))
         {
          _drikkevarerRepo[nummer] = opdateretDrikkevarer;
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }

        public Drikkevarer HentDrikkevarer(int nummer)
        { 
         if (_drikkevarerRepo.ContainsKey(nummer))
         {
          return _drikkevarerRepo[nummer];
         }
         else
         {
          throw new KeyNotFoundException("Nummer findes ikke");
         }
        }
        
        public List<Drikkevarer> HentAlleDrikkevarer()
        {
         return _drikkevarerRepo.Values.ToList();
        }

        public int GetSidsteNummer()
        {
         if (!_drikkevarerRepo.Any())
         {
          return 1;
         }
         else
         {
          int sidsteNummer = _drikkevarerRepo.Keys.Max();
          return sidsteNummer + 1;
         }
        }

        private const string fileName = "DrikkevarerRepository.json";

        private Dictionary<int, Drikkevarer> ReadFromJson()
        {
         if (File.Exists(fileName))
         {
          StreamReader reader = File.OpenText(fileName);
          Dictionary<int, Drikkevarer> drikkevarerRepo =
           JsonSerializer.Deserialize<Dictionary<int, Drikkevarer>>(reader.ReadToEnd());
          reader.Close();
          return drikkevarerRepo;
         }
         else
         {
          return new Dictionary<int, Drikkevarer>();
         }
        }

        private void WriteToJson()
        {
         FileStream fs = new FileStream(fileName, FileMode.Create);
         Utf8JsonWriter writer = new Utf8JsonWriter(fs);
         JsonSerializer.Serialize(writer, _drikkevarerRepo);
         fs.Close();
        }
    }
}