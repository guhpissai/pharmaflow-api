using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class ItemVendaProfile : Profile
{
    public ItemVendaProfile()
    {
        CreateMap<ItemVendaCreateDto, ItemVenda>();
        CreateMap<ItemVenda, ItemVendaSearchDto>()
            .ForMember(dest => dest.MedicamentoNome, opt => opt.MapFrom(m => m.Medicamento));
    }
}
