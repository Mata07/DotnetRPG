using AutoMapper;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
