using System;

namespace Cars.Sales.Core.Domain.ValueObjects;

public class Equipment : ValueObject<Equipment>
{
    private Equipment()
    {
    }

    public Equipment(string code, string name)
    {
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException(nameof(code));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

        Code = code;
        Name = name;
    }

    public string Code { get; private set; }
        
    public string Name { get; private set; }
}