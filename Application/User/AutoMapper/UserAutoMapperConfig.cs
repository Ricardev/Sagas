using AutoMapper;

namespace Application.User.AutoMapper;

public static class UserAutoMapperConfig
{
    public static MapperConfiguration UserRegisterMapping()
    {
        return new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new UserDomainToViewModel());
            configuration.AddProfile(new UserViewModelToDomain());
        });
    }
}