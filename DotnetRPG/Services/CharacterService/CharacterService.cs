using AutoMapper;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam"}
        };


        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            //    characters.Add(newCharacter);
            //    return characters;

            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //characters.Add(_mapper.Map<Character>(newCharacter));

            // tražimo zadnji Id i dodajemo novi
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);

            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                // FirstOrDefualt returns null if not found
                // First throws exception if not found
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);

                serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                // šaljemo poruke iz ServiceResponse
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            //return characters;
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            //return characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                // Ne radimo sa AutoMapperom kako ne bi pregazili sve propertiese
                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;
                // Mapiramo character u GetCharacterDto
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                // šaljemo poruke iz ServiceResponse
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }


    }
}
