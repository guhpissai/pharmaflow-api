using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class MecicamentoProfile : Profile
{
    public MecicamentoProfile()
    {
        CreateMap<MedicamentoCreateDto, Medicamento>();
        CreateMap<Medicamento, MedicamentoSearchDto>();
        CreateMap<MedicamentoUpdateDto, Medicamento>();
    }
}
