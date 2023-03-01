using AutoMapper;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();  // Character to GetCharacterDto
            CreateMap<AddCharacterDto, Character>();    //AddCharacterDto -> Character
        }
    }
}
