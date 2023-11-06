namespace NewMenuPizza.PizzaFolderTest
{
    public class Ingrediens
    {
        private string _n1;
        private string _n2;
        private string _n3;


        public string N1
        {
            get { return _n1; }
            set { _n1 = value; }
        }

        public string N2
        {
            get { return _n2; }
            set { _n2 = value; }
        }

        public string N3
        {
            get { return _n3; }
            set { _n3 = value; }
        }
            

        public Ingrediens()
        {
            _n1 = "";
            _n2 = "";
            _n3 = "";
        }

        public Ingrediens(string n1, string n2, string n3)
        {
            _n1 = n1;
            _n2 = n2;
            _n3 = n3;
        }

        public override string ToString()
        {
            return $"{{{nameof(N1)}={N1}, {nameof(N2)}={N2}, {nameof(N3)}={N3}}}";
        }
    }
}
