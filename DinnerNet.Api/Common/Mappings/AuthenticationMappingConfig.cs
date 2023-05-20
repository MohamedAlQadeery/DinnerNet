using DinnerNet.Application.Authentication.Commands;
using DinnerNet.Application.Authentication.Common;
using DinnerNet.Application.Authentication.Queries;
using DinnerNet.Contracts.Authentication;
using Mapster;

namespace DinnerNet.Api.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
