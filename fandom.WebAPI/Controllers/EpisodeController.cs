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
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _service;
        public EpisodeController(IEpisodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<MEpisode> Get([FromQuery] EpisodesSeasonRequest search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public MEpisode GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public MEpisode Insert(EpisodeInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{id}")]
        public MEpisode Delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpPut("{id}")]
        public MEpisode Update(int id, EpisodeUserActivityRequest request) => _service.Update(id,request);

        [HttpPut("Update/{id}")]
        public MEpisode Update(int id, EpisodeUpdateRequest request) => _service.Update(id, request);


    }
}
