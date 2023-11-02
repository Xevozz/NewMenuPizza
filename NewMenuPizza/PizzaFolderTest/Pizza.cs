namespace NewMenuPizza.PizzaFolderTest
{
    public class Pizza
    {
        // instans felter

        private string _navn;
        private int _pris;
        private int _nummer;
  
        // properties

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public int Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        public int Nummer
        {
            get { return _nummer; }
            set { _nummer = value; }
        }

        //  Default Constructor

        public Pizza()
        {
            _navn = "";
            _pris = 0;
            _nummer = 0;
        }

        public Pizza(string navn, int pris, int nummer)
        {
            _navn = navn;
            _pris = pris;
            _nummer = nummer;

        }
    }
}

