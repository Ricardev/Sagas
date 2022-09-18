using AutoMapper;
using Domain.Products.Command;
using MessageBroker.EventModels;

namespace Application.Products.AutoMapper;

public class EventToDomain : Profile
{
    public EventToDomain()
    {
        CreateMap<ReserveProductEventModel, OrderProductCommand>();
        CreateMap<RollbackProductEventModel, RollbackOrderProductCommand>();
    }
}