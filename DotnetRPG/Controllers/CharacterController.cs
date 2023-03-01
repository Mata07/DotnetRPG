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


        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
            //characters.Add(newCharacter);
            //return Ok(characters);
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

    }
}
