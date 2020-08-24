using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly AppCtx ctx;
        private readonly IMapper _mapper;

        public EpisodeService(AppCtx context, IMapper mapper)
        {
            ctx = context;
            _mapper = mapper;
        }

        public MEpisode Delete(int id)
        {
            var result = ctx.Episodes.Include(x => x.MediaFile).Include(x => x.Season).Where(x => x.Id == id).FirstOrDefault();

            if(result.Season != null)
            {
                result.Season.Episodes.Remove(result);

                if (--result.Season.NoOfEpisodes == 0)
                {
                    ctx.Seasons.Remove(result.Season);
                }

            }

            ctx.Episodes.Remove(result);
            ctx.MediaFiles.Remove(result.MediaFile);

            ctx.SaveChanges();

            return _mapper.Map<MEpisode>(result);
        }

        public List<MEpisode> Get(EpisodesSeasonRequest request)
        {
            var result = new List<Episode>();

            if(request.SeasonId != null)
            {
                var query = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).Where(x => x.SeasonId == request.SeasonId).ToList();
                result = query;
            }
            else if(request.isAssigned != null)
            {
                if (request.isAssigned == true)
                {
                    var query2 = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).Where(x => x.Season != null).ToList();
                    result = query2;
                }
                else
                {
                    var query3 = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).Where(x => x.Season == null).ToList();
                    result = query3;
                }
            }
            else
            {
                var query4 = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).ToList();
                result = query4;
            }

            return _mapper.Map<List<MEpisode>>(result);
        }

        public MEpisode GetById(int episodeId)
        {
            var result = ctx.Episodes.Include(x => x.MediaFile).Include(x => x.Season).Include(x => x.EpisodesCharacters).Where(x => x.Id == episodeId).FirstOrDefault();

            var episode = _mapper.Map<MEpisode>(result);
            var characters = ctx.EpisodeCharacters.Where(x => x.EpisodeId == episodeId).Select(x => x.Character).ToList();
            episode.Characters = _mapper.Map<List<MCharacter>>(characters);


            return episode;
        }

        public MEpisode Insert(EpisodeInsertRequest request)
        {
            request.OverallNumberOfEpisode = ctx.Episodes.Count() + 1;
            var ep = _mapper.Map<Episode>(request);
            
            ctx.Episodes.Add(ep);



            ctx.SaveChanges();

            foreach (var c in request.MainCharacters)
            {
                var mc = new EpisodeCharacter { CharacterId = c.Id, EpisodeId = ep.Id };
                ctx.EpisodeCharacters.Add(mc);
            }

            ctx.SaveChanges();

            return _mapper.Map<MEpisode>(ep);
        }

        
    }
}
