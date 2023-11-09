using Microsoft.AspNetCore.Routing.Constraints;
using NewMenuPizza.PizzaFolderTest;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Text.Json;

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
        public PizzaRepository()
        {
            _pizzarepo = ReadFromJson();
         
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
            WriteToJson();
        }


        // Fjern Pizzanummer
        public void Fjern(int nummer)
        {
            if (_pizzarepo.ContainsKey(nummer))
            {
                _pizzarepo.Remove(nummer);
                WriteToJson();
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
                WriteToJson();
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

        public const string FILENAME = "PizzaRepository.Json";
        private Dictionary<int, Pizza> ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                return JsonSerializer.Deserialize<Dictionary<int, Pizza>>(sr.ReadToEnd());
            }
            else
            {
                return new Dictionary<int, Pizza>();
            }
        }

        private void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _pizzarepo);
            fs.Close();
        }
    }
}
