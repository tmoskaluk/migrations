using Cars.Sales.Core.Application.DataTransferObjects;

namespace Cars.Sales.Core.Application;

public interface IOrdersApplicationService
{
    OrderDto PlaceOrder(OfferDto offer, SalesCustomerDto customer);

    void ApplyDiscount(int orderId, decimal discount, string comment);
}