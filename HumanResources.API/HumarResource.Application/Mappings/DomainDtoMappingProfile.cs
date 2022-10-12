using AutoMapper;
using HumanResources.Domain.Entities;
using HumarResource.Application.DTO;
using HumarResource.Application.Extensions;

namespace HumarResource.Application.Mappings
{
    public class DomainDtoMappingProfile : Profile
    {
        public DomainDtoMappingProfile()
        {
            CreateMap<Colaborador, ColaboradorDTO>()
                     .ForMember(x => x.DataDeNascimento, x => x.MapFrom(u => u.DataDeNascimento.ToString()));

            CreateMap<ColaboradorDTO, Colaborador>()
            .ForMember(x => x.DataDeNascimento, x => x.MapFrom(u => u.DataDeNascimento.ToDate()));

            CreateMap<CargoFuncao, CargoFuncaoDTO>().ReverseMap();

            CreateMap<Contrato, ContratoDTO>()
                .ForMember(x => x.DataDeInicio, x => x.MapFrom(u => u.DataDeInicio.ToString()));

            CreateMap<ContratoDTO, Contrato>()
                .ForMember(x => x.DataDeInicio, x => x.MapFrom(u => u.DataDeInicio.ToDate()));
        }
    }
}
