using AgroConecta.Domain.Sistema.Auditoria;
using AgroConecta.Domain.Sistema.General;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Tipos;
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
        
        //Tipos
        CreateMap<TipoMedidaArea, TipoMedidaAreaDTO>().ReverseMap();
        CreateMap<TipoSuelo, TipoSueloDTO>().ReverseMap();
        CreateMap<TipoArrendamiento, TipoArrendamientoDTO>().ReverseMap();
        CreateMap<TipoCultivo, TipoCultivoDTO>().ReverseMap();
        CreateMap<Municipio, MunicipioDTO>().ReverseMap();
        CreateMap<Provincia, ProvinciaDTO>().ReverseMap();

        // CreateMap<ApplicationUser, UsuarioDto>()
        //     .ForMember(x => x.BalanceCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Balance))
        //     .ForMember(x => x.NumeroCuenta, y => y.MapFrom(x => x.Accounts.FirstOrDefault().Number));

    }
}
