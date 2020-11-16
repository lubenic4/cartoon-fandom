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
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<MPost> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public MPost GetById(int id) => _service.GetById(id);

        [HttpPost]
        public MPost Insert(PostInsertRequest request) => _service.Insert(request);

        [HttpPut("{id}")]
        public MPost Update(int id, PostUpdateRequest request) => _service.Update(id, request);


    }
}
