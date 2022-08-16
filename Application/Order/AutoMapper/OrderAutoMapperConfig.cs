using AutoMapper;

namespace Application.Order.AutoMapper;

public static class OrderAutoMapperConfig
{
    public static MapperConfiguration RegisterOrderMapping()
    {
        return new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new OrderDomainToViewModel());
            configuration.AddProfile(new OrderViewModelToDomain());
        });
    }
}