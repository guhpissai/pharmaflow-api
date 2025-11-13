using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class MedicamentoProfile : Profile
{
    public MedicamentoProfile()
    {
        CreateMap<MedicamentoCreateDto, Medicamento>();
        CreateMap<Medicamento, MedicamentoSearchDto>()
            .ForMember(m => m.FornecedorNome, opt => opt.MapFrom(src => src.Fornecedor.RazaoSocial));
        CreateMap<MedicamentoUpdateDto, Medicamento>();
    }
}
