// File-scoped namespace
namespace Todo.Models;

// class låter oss definiera nya datatyper - en datatyp av data och beteende
public class Task
{
    // En konstruktor ansvarar för att säkerställa att objekt skapas i ett giltigt tillstånd
    // Den anropas när man skapar ett objekt (new Task())
    public Task(string name)
    {
        Name = name; // detta kommer anropa set-delen av Name
    }

    public Task(string name, bool completed)
    {
        Name = name; // detta kommer anropa set-delen av Name
        Completed = completed;
    }

    public Task(int id, string name, bool completed)
    {
        Id = id;
        Name = name; // detta kommer anropa set-delen av Name
        Completed = completed;
    }

    // Properties (auto-implemented property)
    public int? Id { get; set; } // null

    private string? name; // null

    // task.Name = "Städa"               - detta anropar set-delen av Name
    // Console.WriteLine(task.Name);     - detta anropat get-delen av Name
    public string Name {
        get => name;
        set
        {
            // Vi behöver säkerställa att name inte är null eller en tom stäng ("") - vi kallar detta för validering
            if (string.IsNullOrEmpty(value.Trim()))
            {
                // Throw låter oss lyfta exekveringen från en punkt till en annan
                throw new Exception($"{nameof(Name)} must be a string between 1-50 characters");
            }

            name = value;
        }
    }

    // Auto-implemented property
    // Den atomatiskt skapar ett bakomliggnade fält (backing field) där värdet lagras
    
    public bool Completed { get; set; }

    public string SuperSecret { get; set; }
}
