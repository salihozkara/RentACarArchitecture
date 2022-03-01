using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Fuel:Entity
{
    public Fuel()
    {
        Models = new HashSet<Model>();
    }

    public Fuel(int id, string name, ICollection<Model> models) : this()
    {
        Id = id;
        Name = name;
        Models = models;
    }

    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }
}