using Core.Persistence.Repositories;

namespace Domain.Entities;

// Transmission has a make name
public class Transmission : Entity
{
    // Constructor
    public Transmission()
    {
        Models = new HashSet<Model>();
    }

    public Transmission(int id, string name) : this()
    {
        Name = name;
        Id = id;
    }

    // Properties
    public string Name { get; set; }
    // Navigation Properties
    public virtual ICollection<Model> Models { get; set; }
}