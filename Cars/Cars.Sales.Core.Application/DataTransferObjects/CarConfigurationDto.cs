using Cars.SharedKernel.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cars.Sales.Core.Application.DataTransferObjects;

public class CarConfigurationDto
{
    [Required]
    public string Model { get; set; }

    [Required]
    public CarColor Color { get; set; }

    [Required]
    public EquipmentVersion Version { get; set; }

    [Required]
    public GearboxType GearboxType { get; set; }

    [Required]
    public string EngineCode { get; set; }

    [Required]
    public EngineType EngineType { get; set; }

    [Required]
    public int EngineCapacity { get; set; }
}