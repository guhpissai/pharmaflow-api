using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, VendaSearchDto>()
            .ForMember(dest => dest.ClienteNome, opt =>  opt.MapFrom(src => src.Cliente.RazaoSocial));
        CreateMap<VendaCreateDto, Venda>();
        CreateMap<VendaUpdateDto, Venda>();
    }
}
