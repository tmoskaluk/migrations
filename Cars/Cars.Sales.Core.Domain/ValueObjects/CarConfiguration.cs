using Cars.SharedKernel.Enums;
using System;

namespace Cars.Sales.Core.Domain.ValueObjects;

public class CarConfiguration : ValueObject<CarConfiguration>
{
    public const int ModelMaxLength = 50;

    private CarConfiguration()
    {
    }

    public CarConfiguration(string model, Engine engine, GearboxType gearboxType, EquipmentVersion version, CarColor color)
    {
        if (string.IsNullOrWhiteSpace(model) || model.Length > ModelMaxLength) throw new ArgumentException(nameof(model));

        Model = model;
        Engine = engine;
        GearboxType = gearboxType;
        Version = version;
        Color = color;
    }
        
    public string Model { get; private set; }
        
    public Engine Engine { get; private set; }

    public GearboxType GearboxType { get; private set; }

    public EquipmentVersion Version { get; private set; }
        
    public CarColor Color { get; private set; }
}