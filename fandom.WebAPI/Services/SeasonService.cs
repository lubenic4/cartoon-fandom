using AutoMapper;
using fandom.Model.Models;
using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly AppCtx _context;
        private readonly IMapper _mapper;

        public SeasonService(AppCtx context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MSeason> Get() => _mapper.Map<List<MSeason>>(_context.Seasons.ToList());
    }
}
