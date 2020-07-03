using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fandom.Model.Models;
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
        public ActionResult<List<MSeason>> GetAll() => _service.Get();
    }
}
