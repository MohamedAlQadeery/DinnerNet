using DinnerNet.Application.Dinners.Commands;
using DinnerNet.Contracts.Dinners;
using Mapster;

namespace DinnerNet.Api.Common.Mappings;

public class DinnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateDinnerRequest request, string HostId), CreateDinnerCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.request);

    }
}
