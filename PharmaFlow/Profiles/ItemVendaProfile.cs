using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class ItemVendaProfile : Profile
{
    public ItemVendaProfile()
    {
        CreateMap<ItemVendaCreateDto, ItemVenda>();
    }
}
