using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fandom.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace fandom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch> : ControllerBase
    {
        private readonly IBaseService<TModel, TSearch> _service;

        public BaseController(IBaseService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<TModel> Get([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public TModel GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
