using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile(Mapper mapper)
        {
            CreateMap<Venda, VendaSearchDto>();
            CreateMap<VendaCreateDto, Venda>();
            CreateMap<VendaUpdateDto, Venda>();
        }
    }
}
