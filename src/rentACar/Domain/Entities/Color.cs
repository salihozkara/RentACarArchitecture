using Core.Persistence.Repositories;

// Color has a make name
namespace Domain.Entities
{
    public class Color : Entity
    {
        // Constructors
        public Color()
        {
            Cars = new HashSet<Car>();
        }

        public Color(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        // Properties
        public string Name { get; set; }

        // Navigation Properties
        public virtual ICollection<Car> Cars { get; set; }
    }
}