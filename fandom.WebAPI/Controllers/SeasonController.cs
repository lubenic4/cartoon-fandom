using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fandom.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _service;
        public SeasonController(ISeasonService service) 
        {
            _service = service;
        }

        [HttpGet]
        public List<MSeason> Get([FromQuery] object search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public MSeason GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public MSeason Insert(SeasonInsertRequest request)
        {
          return  _service.Insert(request);
        }

    }
}
