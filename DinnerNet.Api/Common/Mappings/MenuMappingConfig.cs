using DinnerNet.Application.Menus.Commands;
using DinnerNet.Contracts.Menus;
using Mapster;

namespace DinnerNet.Api.Common.Mappings;

public class MenuMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.request)
        ;
    }
}
