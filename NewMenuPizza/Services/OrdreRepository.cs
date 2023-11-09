using NewMenuPizza.OrdreFolder;

namespace NewMenuPizza.Services;

public class OrdreRepository
{
    /*
     * Instans fields
     */
    private Dictionary<int, Ordre> _ordreRepo;

    /*
     * Properties
     */
    public Dictionary<int, Ordre> OrdreRepo
    {
     get { return _ordreRepo; }
     set { _ordreRepo = value; }
    }

    /*
     * Constructor
     */
    public OrdreRepository()
    {
     _ordreRepo = new Dictionary<int, Ordre>();
    }


    /*
     * Methods
     */
    public void TilføjOrdre(int ordreId, Ordre ordre)
    {
     if (!_ordreRepo.ContainsKey(ordreId))
     {
      _ordreRepo.Add(ordreId, ordre);
     }
     else
     {
      throw new KeyNotFoundException("");
     }
    }

    public List<Ordre> HentAlleOrdre()
    {
     return _ordreRepo.Values.ToList();
    }
}