using DotnetRPG.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
        //Task<List<Character>> GetAllCharacters();
        // Napravili smo wrapper ServiceResponse i dodali ga
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}
