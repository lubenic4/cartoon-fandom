using AutoMapper;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly AppCtx ctx;
        private readonly IMapper _mapper;

        public SeasonService(AppCtx context, IMapper mapper) 
        {
            ctx = context;
            _mapper = mapper;
        }

        public  List<MSeason> Get(object search)
        {
            var list = ctx.Set<Season>().ToList();

            return _mapper.Map<List<MSeason>>(list);
        }

        public  MSeason GetById(int id)
        {
            var result = ctx.Seasons.Include(x => x.Episodes).Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<MSeason>(result);
        }

        public MSeason Insert(SeasonInsertRequest request)
        {
            var episodes = request.Episodes.OrderBy(x => x.AirDate).ToList();
            var ordinalNumber = ctx.Seasons.Count() + 1;
            var season = new Season
            {
                NoOfEpisodes = episodes.Count(),
                OrdinalNumber = ordinalNumber,
                PremiereDate = (DateTime)episodes.First().AirDate,
                Summary = "test test",
                Episodes = new List<Episode>()

            };



            ctx.Seasons.Add(season);

            season.Episodes = _mapper.Map<List<Episode>>(episodes);


            //var epIds = new List<int>();
            //foreach(var items in episodes)
            //{
            //    epIds.Add(items.Id);
            //}

            //var dbEpisodes = ctx.Episodes.Where(x => epIds.Contains(x.Id)).ToList();
            //dbEpisodes.ForEach(x =>
            //{
            //    x.Season = season;
            //    x.Id = season.Id;
            //});

            ctx.SaveChanges();

            return _mapper.Map<MSeason>(season);
        }
    }
}
