using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission : Entity
{
    public Transmission()
    {
        Models = new HashSet<Model>();
    }

    public Transmission(int id, string name) : this()
    {
        Name = name;
        Id = id;
    }

    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }
}