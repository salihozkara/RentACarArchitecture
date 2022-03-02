using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car:Entity
{
    public Car()
    {
    }
    
    public Car(int id, int modelId, string plate, short modelYear, int colorId,CarState carState) : this()
    {
        Id = id;
        ModelId = modelId;
        Plate = plate;
        ModelYear = modelYear;
        ColorId = colorId;
        CarState = carState;
    }

    public int ModelId { get; set; }
    public string Plate { get; set; }
    public short ModelYear { get; set; }
    public int ColorId { get; set; }
    public CarState CarState { get; set; }

    public virtual Color Color { get; set; }
    public virtual Model Model { get; set; }

}