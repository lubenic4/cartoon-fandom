using AutoMapper;
using fandom.Model.Models;
using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class RoleService : IRoleService
    {

        private readonly AppCtx _ctx;
        private readonly IMapper _mapper;

        public RoleService(AppCtx context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public List<MRole> Get()
        {
            var result = _ctx.Roles.ToList();

            return _mapper.Map<List<MRole>>(result);
        }
    }
}
