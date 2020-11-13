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

        [HttpGet("{id}")]
        public MCharacter GetById(int id) => _service.GetById(id);

        [HttpPost]
        public MCharacter InsertCharacter(CharacterInsert request) => _service.Insert(request);

        [HttpGet]
        public List<MCharacter> Get() => _service.Get();

        [HttpPut("{id}")]
        public MCharacter UpdateCharacter(int id, CharacterUpdateRequest request) => _service.Update(id, request);

        [HttpDelete("{id}")]
        public MCharacter Delete(int id) => _service.Delete(id);
    }
}
