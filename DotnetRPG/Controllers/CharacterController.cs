using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using DotnetRPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetRPG.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        //[Route("GetAll")]
        [HttpGet("GetAll")] // Route i action u jednom
        public async Task<IActionResult> Get()
        {
            //return Ok(characters);
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            //return Ok(characters.FirstOrDefault(c => c.Id == id));
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            //characters.Add(newCharacter);
            //return Ok(characters);
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            // check if Character Id is not real, return 404
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null) 
            { 
                return NotFound(response);  // return 404
            }

            return Ok(response);
        }
    }
}
