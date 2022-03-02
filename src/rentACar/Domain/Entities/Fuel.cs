using Core.Persistence.Repositories;

namespace Domain.Entities;

// Fuel has a make name
public class Fuel : Entity
{
    // Constructor
    public Fuel()
    {
        Models = new HashSet<Model>();
    }

    public Fuel(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
    // Properties
    public string Name { get; set; }
    // Navigation Properties
    public virtual ICollection<Model> Models { get; set; }
}