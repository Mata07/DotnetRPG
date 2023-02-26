using DotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            new Character { Name = "Sam"}
        };

        //[Route("GetAll")]
        [HttpGet("GetAll")] // Route i action u jednom
        public IActionResult Get()
        {
            return Ok(characters);
        }

        public IActionResult GetSingle()
        {
            return Ok(characters[0]);
        }


    }
}
