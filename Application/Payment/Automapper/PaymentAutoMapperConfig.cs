using AutoMapper;

namespace Application.Payment.Automapper;

public static class PaymentAutoMapperConfig
{
    public static MapperConfiguration RegisterPaymentMapping()
    {
        return new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new PaymentDomainToViewModel());
            configuration.AddProfile(new PaymentViewModelToDomain());
        });
    }
}