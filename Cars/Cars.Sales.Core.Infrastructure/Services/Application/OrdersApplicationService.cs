using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Cars.Sales.Core.Domain;
using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Domain.Repositories;
using Cars.Sales.Core.Domain.ValueObjects;
using Cars.SharedKernel;

namespace Cars.Sales.Core.Infrastructure.Services.Application;

public class OrdersApplicationService(IAppLogger logger, IOrdersRepository ordersRepository, IOffersRepository offersRepository, ISalesUnitOfWork unitOfWork)
    : IOrdersApplicationService
{
    public OrderDto PlaceOrder(OfferDto offerDto, SalesCustomerDto customerDto)
    {
        var offer = offersRepository.Get(offerDto.Id);
        var customer = new Customer(customerDto.CustomerId, customerDto.Name);
        var order = Order.Create(offer, customer);
            
        ordersRepository.Add(order);
        unitOfWork.Commit();

        logger.Info($"Order created [OrderId = {order.Id}, CustomerId = {order.Customer.CustomerId}]");
        return new OrderDto { OrderId = order.Id };
    }

    public void ApplyDiscount(int orderId, decimal discount, string comment)
    {
        var order = ordersRepository.Get(orderId);
        order.ApplyDiscount(discount);
        order.AddComment(comment);

        unitOfWork.Commit();
        logger.Info($"Discount applied [OrderId = {order.Id}, Discount = {discount}]");
    }

    public void Reject(int orderId)
    {
        var order = ordersRepository.Get(orderId);
        order.Reject();
        unitOfWork.Commit();
        logger.Info($"Order rejected [OrderId = {order.Id}]");
    }
}