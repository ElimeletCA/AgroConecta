using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Seguridad;
using AutoMapper;

namespace AgroConecta.Application.Mapper.Profiles;

public class SeguridadProfile : Profile
{
    public SeguridadProfile()
    {
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<Usuario, UsuarioDTO>();
        // CreateMap<ApplicationUser, UsuarioDto>()
        //     .ForMember(x => x.BalanceCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Balance))
        //     .ForMember(x => x.NumeroCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Number));

    }
}
