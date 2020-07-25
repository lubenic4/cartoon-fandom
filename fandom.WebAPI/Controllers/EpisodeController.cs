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

    public class EpisodeController : BaseController<MEpisode, object>
    {
        public EpisodeController(IBaseService<MEpisode, object> service) : base(service)
        {
        }
    }
}
