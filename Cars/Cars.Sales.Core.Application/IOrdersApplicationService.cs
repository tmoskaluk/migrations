using Cars.Sales.Core.Application.DataTransferObjects;
using System;

namespace Cars.Sales.Core.Application;

public interface IOrdersApplicationService
{
    OrderDto PlaceOrder(Guid offerId, SalesCustomerDto customer);

    void ApplyDiscount(int orderId, decimal discount, string comment);

    void ConfirmOrder(int orderId, DateTime plannedDeliveryDate);

    void FinalizeOrder(int orderId, DateTime receivedDate);

    void RejectOrder(int orderId);
}