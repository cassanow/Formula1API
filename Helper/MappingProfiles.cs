using AutoMapper;
using Formula1API.DTO;
using Formula1API.Model;

namespace Formula1API.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Equipe, EquipeDTO>().ReverseMap();
        CreateMap<Piloto, PilotoDTO>().ReverseMap();
    }
}