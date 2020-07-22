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

    public class SeasonController : BaseController<MSeason, object>
    {
        public SeasonController(IService<MSeason, object> service) : base(service)
        {
        }
    }
}
