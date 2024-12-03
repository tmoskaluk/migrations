using Cars.SharedKernel.Enums;
using System;

namespace Cars.Sales.Core.Domain.ValueObjects;

public class CarConfiguration : ValueObject<CarConfiguration>
{
    public const int ModelMaxLength = 50;

    private CarConfiguration()
    {
    }

    public CarConfiguration(string model, Engine engine, EquipmentVersion version)
    {
        if (string.IsNullOrWhiteSpace(model) || model.Length > ModelMaxLength) throw new ArgumentException(nameof(model));

        Model = model;
        Engine = engine;
        Version = version;
    }
        
    public string Model { get; private set; }
        
    public Engine Engine { get; private set; }

    public EquipmentVersion Version { get; private set; }
}