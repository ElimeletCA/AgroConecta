using AgroConecta.Domain.Sistema.Auditoria;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AgroConecta.Application.Mapper.Profiles;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<Usuario, UsuarioDTO>();
        CreateMap<RolDTO, IdentityRole>();
        CreateMap<IdentityRole, RolDTO>();
        CreateMap<TipoMedidaArea, TipoMedidaAreaDTO>().ReverseMap();

        // CreateMap<ApplicationUser, UsuarioDto>()
        //     .ForMember(x => x.BalanceCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Balance))
        //     .ForMember(x => x.NumeroCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Number));

    }
}
