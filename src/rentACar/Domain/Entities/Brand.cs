using Core.Persistence.Repositories;

namespace Domain.Entities;

// Brand has a make name
public class Brand : Entity
{
    // Constructor
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    // Properties
    public string Name { get; set; }

    // Navigation Properties
    public virtual ICollection<Model> Models { get; set; }
}