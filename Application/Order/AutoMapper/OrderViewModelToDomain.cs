using Application.Order.Models;
using AutoMapper;
using Domain.Order.Command;

namespace Application.Order.AutoMapper;

public class OrderViewModelToDomain : Profile
{
    public OrderViewModelToDomain()
    {
        CreateMap<MakeOrderModel, CreateOrderCommand>();
    }
}