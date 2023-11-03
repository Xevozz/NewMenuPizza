using NewMenuPizza.Model;
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
            _katalog = new Dictionary<int, Kunde>();


            if (mockData )
            {
                PopulateKundeRepository();
            }
        }

        public void PopulateKundeRepository()
        {
            _katalog.Clear();

            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Jens", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Pete", GetSidsteNummer(), "11223344"));
            _katalog.Add(GetSidsteNummer(), new Kunde("Emil", GetSidsteNummer(), "11223344"));

        }
        
         //metoder
         
        public Kunde Tilføj(Kunde kunde)
        {
            _katalog.Add(kunde.KundeNummer, kunde);

            return kunde;
        }

        public Kunde Slet(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                Kunde slettetKunde = _katalog[kundenummer];
                _katalog.Remove(kundenummer);
                return slettetKunde;

            }
            else
            {
                return null;
            }
        }

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


}
