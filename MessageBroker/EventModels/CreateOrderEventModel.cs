﻿namespace MessageBroker.EventModels;

public class CreateOrderEventModel
{
    public int OrderId { get; }
    public int UserId { get; }
    public int ProductId { get; }
    public int Quantity { get; }

    public CreateOrderEventModel(int orderId, int userId, int productId, int quantity)
    {
        OrderId = orderId;
        UserId = userId;
        ProductId = productId;
        Quantity = quantity;
    }
}