using Cars.SharedKernel.Enums;
using System;

namespace Cars.Sales.Core.Domain.ValueObjects;

public class Engine : ValueObject<Engine>
{
    public Engine(string code, EngineType type, int capacity)
    {
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Missing engine code", nameof(code));
        if (capacity <= 0) throw new ArgumentException("Wrong engine capacity", nameof(capacity));

        Code = code;
        Type = type;
        Capacity = capacity;
    }

    public string Code { get; private set; }

    public EngineType Type { get; private set; }

    public int Capacity { get; private set; }
}