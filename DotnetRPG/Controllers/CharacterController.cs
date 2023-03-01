using DotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetRPG.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam"}
        };

        //[Route("GetAll")]
        [HttpGet("GetAll")] // Route i action u jednom
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }


        public IActionResult AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }

    }
}
