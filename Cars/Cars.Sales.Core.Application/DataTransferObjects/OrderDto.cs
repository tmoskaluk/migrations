using Cars.SharedKernel.Enums;

namespace Cars.Sales.Core.Application.DataTransferObjects;

public class OrderDto
{
    public int OrderId { get; set; }

    public OrderStatus Status { get; set; }
}