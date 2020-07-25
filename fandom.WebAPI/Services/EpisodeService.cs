using AutoMapper;
using fandom.Model.Models;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class EpisodeService : BaseService<MEpisode, object, Episode>
    {


        public EpisodeService(AppCtx context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
