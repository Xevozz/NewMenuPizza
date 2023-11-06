using NewMenuPizza.PizzaFolderTest;

namespace NewMenuPizza.Services
{

    public class IngrediensRepository
    {
        Dictionary<string, Ingrediens> _ingrediensrepo;

        public Dictionary<string, Ingrediens> Ingrediensrepo
        {
            get { return _ingrediensrepo; }
            set { _ingrediensrepo = value; }
        }

        public IngrediensRepository(bool mockdata = false)
        {
            _ingrediensrepo = new Dictionary<string, Ingrediens>();

            if (mockdata)
            {
                _ingrediensrepo.Clear();
                Tilføj(new Ingrediens("DeepPan", "Familie", "Vegansk"));
            }
        }

        // Metoder

        // Tilføj Ingrediens

        public Ingrediens Tilføj(Ingrediens ingrediens)
        {
            _ingrediensrepo.Add(ingrediens.N1, ingrediens);
            return ingrediens;
        }

        // Hent Alle Ingredienser
        public List<Ingrediens> HentAlleIngredienser()
        {
            return _ingrediensrepo.Values.ToList();
        }

    }
}