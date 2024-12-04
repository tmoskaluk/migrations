using System;
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
    public OrderDto PlaceOrder(Guid offerId, SalesCustomerDto customerDto)
    {
        var offer = offersRepository.Get(offerId);
        if (offer == null) throw new ArgumentException("Invalid offer identifier");
        var customer = new Customer(customerDto.CustomerId, customerDto.Name);
        var order = Order.Create(offer, customer);
            
        ordersRepository.Add(order);
        unitOfWork.Commit();

        logger.Info($"Order created [OrderId = {order.Id}, CustomerId = {order.Customer.CustomerId}]");
        return new OrderDto
        {
            OrderId = order.Id,
            Status = order.Status
        };
    }

    public void ApplyDiscount(int orderId, decimal discount, string comment)
    {
        var order = ordersRepository.Get(orderId);
        if (order == null) throw new ArgumentException("Invalid order identifier");

        order.ApplyDiscount(discount);
        order.AddComment(comment);

        unitOfWork.Commit();
        logger.Info($"Discount applied [OrderId = {order.Id}, Discount = {discount}]");
    }

    public void ConfirmOrder(int orderId, DateTime plannedDeliveryDate)
    {
        var order = ordersRepository.Get(orderId);
        if (order == null) throw new ArgumentException("Invalid order identifier");

        order.Confirm(plannedDeliveryDate);
        
        unitOfWork.Commit();
        logger.Info($"Order confirmed [OrderId = {order.Id}, PlannedDeliveryDate = {plannedDeliveryDate}]");
    }

    public void FinalizeOrder(int orderId, DateTime receivedDate)
    {
        var order = ordersRepository.Get(orderId);
        if (order == null) throw new ArgumentException("Invalid order identifier");

        order.Finalize(receivedDate);

        unitOfWork.Commit();
        logger.Info($"Order finalized [OrderId = {order.Id}, ReceivedDate = {order.ReceivedDate}]");
    }

    public void RejectOrder(int orderId)
    {
        var order = ordersRepository.Get(orderId);
        if (order == null) throw new ArgumentException("Invalid order identifier");

        order.Reject();

        unitOfWork.Commit();
        logger.Info($"Order rejected [OrderId = {order.Id}]");
    }
}