using EasyLiving.Application.Auth.Commands.Register;
using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Auth.Queries.Login;
using EasyLiving.Contracts.Auth;
using Mapster;

namespace EasyLiving.Api.Commom.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest, src => src.User);
    }
}