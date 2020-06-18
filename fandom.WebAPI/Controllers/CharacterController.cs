using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fandom.Model;
using fandom.Model.Requests;
using fandom.Model.Requests.Character;
using fandom.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fandom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public ActionResult<List<MCharacter>> GetAll() => _service.Get();

        [HttpGet("{id}")]
        public ActionResult<MCharacter> GetById(int id) => _service.GetById(id);

        [HttpPost]
        public ActionResult<MCharacter> InsertCharacter(CharacterInsert request) => _service.Insert(request);

        [HttpGet]
        public ActionResult<List<MCharacter>> Get([FromQuery]CharacterSearchByName request) => _service.SearchByName(request);
    }
}
