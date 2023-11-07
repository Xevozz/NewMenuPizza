using System.Text.Json;
namespace NewMenuPizza.Kunder;

//Dictionary
//instans
//properties
//kontruktør (liste)
//metoder(nykunde, sletkunde, hentkunde)

public class KundeRepository
{
    //instansfelt
        Dictionary<int, Kunde> _katalog;

        //properties
        public Dictionary<int, Kunde> Katalog
        {
            get { return _katalog; }
            set { _katalog = value; }
        }

        //Constructor
        public KundeRepository(bool mockData = false)
        {
            _katalog = ReadFromJson();
            /*_katalog = new Dictionary<int, Kunde>();


            if (mockData )
            {
                PopulateKundeRepository();
            }
        }

        //KundeKatalog tilføjelse
        public void PopulateKundeRepository()
        {
            _katalog.Clear();

            
*/
        }
        
         //metoder
         
        public Kunde Tilføj(Kunde kunde)
        {
            _katalog.Add(kunde.KundeNummer, kunde);
            
            WriteToJson();
            return kunde;
        }

        //Sletning af kunde
        public Kunde Slet(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                Kunde slettetKunde = _katalog[kundenummer];
                _katalog.Remove(kundenummer);
                WriteToJson();
                return slettetKunde;

            }
            else
            {
                return null;
            }
        }

        //
        public Kunde HentKunde(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                return _katalog[kundenummer];

            }
            else
            {
                throw new KeyNotFoundException("kundenummer findes ikke");
                return null;
            }
        }

        public List<Kunde> HentAlleKunder()
        {
            return _katalog.Values.ToList();
        }

        public Kunde HentKundeUdFraTlf(string tlf)
        {
            Kunde resKunde = null;

            foreach (Kunde k in _katalog.Values)
            {
                if (k.Tlf == tlf)
                {
                    return k;
                }
            }

            return resKunde;
        }
        
        public Kunde HentKundeUdFraNummer(int kundenummer)
        {
            Kunde resKunde = null;

            foreach (Kunde k in _katalog.Values)
            {
                if (k.KundeNummer == kundenummer)
                {
                    return k;
                }
            }

            return resKunde;
        }

        //tilføjer Kundenummer til kunde + 1. hver gang.
        public int GetSidsteNummer()
        {
            if (!_katalog.Any())
            {
                return 1;
            }
            else
            {
                int sidsteNummer = _katalog.Keys.Max();
                return sidsteNummer + 1;
            }
        }

        
        public override string ToString()
        {
            String pænTekst = String.Join(", ", _katalog.Values);

            return $"{{{nameof(Katalog)}={pænTekst}}}";
        }
        /*
         * Hjælpe metoder til at læse og skrive til en fil i json format
         */

        private const string FILENAME = "KundeRepository.json";
  
        private Dictionary<int, Kunde> ReadFromJson()
        {
            if ( File.Exists(FILENAME) )
            {
                StreamReader reader = File.OpenText(FILENAME);
                Dictionary<int, Kunde> katalog = JsonSerializer.Deserialize<Dictionary<int, Kunde>>(reader.ReadToEnd());
                reader.Close();
                return katalog;
            }
            else
            {
                return new Dictionary<int, Kunde>();
            }
    
        }
  
        private void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _katalog);
            fs.Close();
        }
    
} 