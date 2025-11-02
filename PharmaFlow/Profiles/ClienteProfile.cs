using AutoMapper;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

namespace PharmaFlow.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteSearchDto>();
    }
}
