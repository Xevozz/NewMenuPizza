using Newtonsoft.Json;
using JsonDocument = System.Text.Json.JsonDocument;
using Utf8JsonWriter = System.Text.Json.Utf8JsonWriter;

namespace NewMenuPizza.OrdreFolder;

public class Ordre
{
    /*
     * Instans fields
     */
    private List<MenuItem> _ordreListe;
    private const string _fileName = "OrdreRepository.json";

    /*
     * Properties
     */
    public List<MenuItem> OrdreListe { get; set; }
    
    
    /*
     * Constructor
     */
    
    public Ordre()
    {
        _ordreListe = new List<MenuItem>();
    }
    
    
      /*
     // * Methods
     // */
     
    public void TilføjMenuItem(MenuItem menuItem)
    {
        _ordreListe.Add(menuItem);
    }

    public double SumAfAlleItems()
    {
        double sum = 0;
        foreach (var element in _ordreListe)
        {
            sum = sum + element.Pris;
        }

        return sum;
    }

    public List<MenuItem> HentAlleOrdre()
    {
        return _ordreListe.ToList();
    }
    
    private List<MenuItem> ReadFromJson()
    {
        if (File.Exists(_fileName))
        {
            using (StreamReader file = File.OpenText(_fileName))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<List<MenuItem>>(reader);
                }
        }
        else
        {
            return new List<MenuItem>();
        }
    }
    
    private void WriteToJson()
    {
        using (StreamWriter file = File.CreateText(_fileName))
        {
            JsonSerializer serializer = new JsonSerializer();
            // Antager at _menuItems er den liste, du vil serialisere
            serializer.Serialize(file, _ordreListe);
        }
    }


}