using System.Text.Json;

namespace NewMenuPizza.Services;

public class MenuItemRepository
{
    private Dictionary<int, MenuItem> _menuItemRepo;
    private const string _fileName = "MenuItemRepository.json";
    
    /*
     * Properties
     */

    public Dictionary<int, MenuItem> MenuItemRepo
    {
        get { return _menuItemRepo; }
        set { _menuItemRepo = value; }
    }
    
    /*
     * Constructor
     */
    public MenuItemRepository()
    {
        _menuItemRepo = ReadFromJson();
    }
    
    /*
     * Methods
     */

    public MenuItem Tilføj(MenuItem menuItem)
    {
        _menuItemRepo.Add(menuItem.Nummer, menuItem);
        WriteToJson();
        return menuItem;
    }

    public void Slet(int nummer)
    {
        if (_menuItemRepo.ContainsKey(nummer))
        {
            _menuItemRepo.Remove(nummer);
            WriteToJson();
        }
        else
        {
            throw new KeyNotFoundException("Nummer findes ikke");
        }
    }

    public void Opdater(int nummer, MenuItem opdateretMenuItem)
    {
        if (_menuItemRepo.ContainsKey(nummer))
        {
            _menuItemRepo[nummer] = opdateretMenuItem;
            WriteToJson();
        }
        else
        {
            throw new KeyNotFoundException("Nummer findes ikke");
        }
    }

    public MenuItem HentMenuItem(int nummer)
    {
        if (_menuItemRepo.ContainsKey(nummer))
        {
            return _menuItemRepo[nummer];
        }
        else
        {
            throw new KeyNotFoundException("Nummer findes ikke");
        }
    }

    public List<MenuItem> HentAlleMenuItems()
    {
        return _menuItemRepo.Values.ToList();
    }

    public int HentSidsteNummer()
    {
        if (!_menuItemRepo.Any())
        {
            return 1;
        }
        else
        {
            int sidsteNummer = _menuItemRepo.Keys.Max();
            return sidsteNummer + 1;
        }
    }

    private Dictionary<int, MenuItem> ReadFromJson()
    {
        if (File.Exists(_fileName))
        {
            StreamReader reader = File.OpenText(_fileName);
            Dictionary<int, MenuItem> menuItemRepo =
                JsonSerializer.Deserialize<Dictionary<int, MenuItem>>(reader.ReadToEnd());
            reader.Close();
            return menuItemRepo;
        }
        else
        {
            return new Dictionary<int, MenuItem>();
        }
    }

    private void WriteToJson()
    {
        FileStream fs = new FileStream(_fileName, FileMode.Create);
        Utf8JsonWriter writer = new Utf8JsonWriter(fs);
        JsonSerializer.Serialize(writer, _menuItemRepo);
        fs.Close();
    }
}