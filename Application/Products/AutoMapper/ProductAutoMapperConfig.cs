using AutoMapper;

namespace Application.Products.AutoMapper;

public static class ProductAutoMapperConfig
{
    public static MapperConfiguration RegisterProductMapping()
    {
        return new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new ProductDomainToViewModel());
            configuration.AddProfile(new ProductViewModelToDomain());
        });
    }
}