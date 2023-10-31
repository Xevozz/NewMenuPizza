

namespace NewMenuPizza.DrikkevarerFolder
{
    public class Drikkevarer
    {
        /*
         * Instance field
         */

        private int _nummer;
        private string _name;
        private double _pris;
        

        /*
         * Properties
         */

        public int Nummer
        {
         get { return _nummer; }
         set { _nummer = value; }
        }

        public string Name
        {
         get { return _name; }
         set { _name = value; }
        }

        public double Pris
        {
         get { return _pris; }
         set { _pris = value; }
        }

        /*
         * Constructor
         */

        public Drikkevarer()
        {
         _nummer = 0;
         _name = "";
         _pris = 0.0;
        }

        public Drikkevarer(int nummer, string name, double pris)
        {
         _nummer = nummer;
         _name = name;
         _pris = pris;
        }

        /*
         * Methods
         */
    } 
}
