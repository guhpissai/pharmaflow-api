using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<FornecedorCreateDto, Fornecedor>();
        CreateMap<Fornecedor, FornecedorSearchDto>()
            .ForMember(f => f.Medicamentos, opt => opt.MapFrom(f => f.Medicamentos));
        CreateMap<FornecedorUpdateDto, Fornecedor>();
    }
}