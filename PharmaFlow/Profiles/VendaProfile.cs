using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, VendaSearchDto>();
        CreateMap<VendaCreateDto, Venda>();
        CreateMap<VendaUpdateDto, Venda>();
    }
}
