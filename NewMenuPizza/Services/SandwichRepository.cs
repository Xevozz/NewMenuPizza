using NewMenuPizza.SandwichFolder;

namespace NewMenuPizza.Services
{
    public class SandwichRepository
    {
        private Dictionary<int, Sandwich> _sandwichRepo;

        public SandwichRepository(bool mockData = false)
        {
            _sandwichRepo = new Dictionary<int, Sandwich>();

            if (mockData)
            {
                _sandwichRepo = new Dictionary<int, Sandwich>()
                {
                    { GetSidsteNummer(), new Sandwich("Kylling", 55, GetSidsteNummer())},
                    { GetSidsteNummer(), new Sandwich("Bacon", 55, GetSidsteNummer())},
                    { GetSidsteNummer(), new Sandwich("Oksekød", 55, GetSidsteNummer())},
                    { GetSidsteNummer(), new Sandwich("Haj", 55, GetSidsteNummer())},
                };
            }
        }

        public void Add(Sandwich sandwich)
        {
            _sandwichRepo.Add(sandwich.Nummer, sandwich);
        }

        public void Remove(int nummer)
        {
            _sandwichRepo.Remove(nummer);
        }

        public Sandwich Update(int nummer, Sandwich opdateretSandwich)
        {
            if (_sandwichRepo.ContainsKey(nummer))
            {
                _sandwichRepo[nummer].Navn = opdateretSandwich.Navn;
                _sandwichRepo[nummer].Pris = opdateretSandwich.Pris;

                return _sandwichRepo[nummer];
            }

            throw new KeyNotFoundException("Nummer findes ikke");
        }

        public Sandwich HentSandwich(int nummer)
        {
            if (_sandwichRepo.TryGetValue(nummer, out var value))
            {
                return value;
            }

            throw new KeyNotFoundException("Nummer findes ikke");
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

            int sidsteNummer = _sandwichRepo.Keys.Max();
            return sidsteNummer + 1;
        }
    }
}