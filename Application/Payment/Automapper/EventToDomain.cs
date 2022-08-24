using AutoMapper;
using Domain.Payment.Command;
using MessageBroker.EventModels;

namespace Application.Payment.Automapper;

public class EventToDomain : Profile
{
    public EventToDomain()
    {
        CreateMap<CreatePaymentEventModel, CreatePaymentCommand>();
    }
}