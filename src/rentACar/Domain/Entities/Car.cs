using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Car:Entity
{
    public Car()
    {
    }
    
    public Car(int id, int modelId, string plate, short modelYear, int colorId) : this()
    {
        Id = id;
        ModelId = modelId;
        Plate = plate;
        ModelYear = modelYear;
        ColorId = colorId;
    }

    public int ModelId { get; set; }
    public string Plate { get; set; }
    public short ModelYear { get; set; }
    public int ColorId { get; set; }

    public virtual Color Color { get; set; }
    public virtual Model Model { get; set; }

}