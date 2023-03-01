using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
        //Task<List<Character>> GetAllCharacters();
        // Napravili smo wrapper ServiceResponse i dodali ga
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}
