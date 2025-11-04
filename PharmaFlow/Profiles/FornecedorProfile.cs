using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<FornecedorCreateDto, Fornecedor>();
        CreateMap<Fornecedor, FornecedorSearchDto>();
        CreateMap<FornecedorUpdateDto, Fornecedor>();
    }
}