using AgroConecta.Domain.Sistema;
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
        
        CreateMap<TerrenoDTO, Terreno>();
         CreateMap<Terreno, TerrenoDTO>()
             .ForMember(x => x.ProvinciaId, y => y.MapFrom(x => x.Municipio.ProvinciaId))
             .ForMember(x => x.NombrePropietario, y => y.MapFrom(x => x.Propietario.nombre_completo))
             .ForMember(x => x.DescripcionTipoSuelo, y => y.MapFrom(x => x.TipoSuelo.Descripcion))
             .ForMember(x => x.DescripcionTipoMedidaArea, y => y.MapFrom(x => x.TipoMedidaArea.Descripcion))

             .ForMember(x => x.DescripcionMunicipio, y => y.MapFrom(x => x.Municipio.Descripcion))
             .ForMember(x => x.DescripcionProvincia, y => y.MapFrom(x => x.Municipio.Provincia.Descripcion));

    }
}
