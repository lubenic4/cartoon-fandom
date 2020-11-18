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

            else if(request.EpisodesIds != null)
            {
                
                var query4 = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).Where(x => request.EpisodesIds.Contains(x.Id)).ToList();
                result = query4;
            }
            else if(request.CharacterId != null)
            {
                var query5 = ctx.EpisodeCharacters.Where(x => x.CharacterId == request.CharacterId).Select(x => new MEpisode
                {
                    AirDate = x.Episode.AirDate,
                    Id = x.Episode.Id,
                    MediaFile = _mapper.Map<MMediaFile>(x.Episode.MediaFile),
                    OverallNumberOfEpisode = (int)x.Episode.OverallNumberOfEpisode,
                    Season = _mapper.Map<MSeason>(x.Episode.Season),
                    SeasonEpisodeNumber = x.Episode.SeasonEpisodeNumber,
                    Summary = x.Episode.Summary,
                    Title = x.Episode.Title,
                    Viewcount = x.Episode.Viewcount,
                    SeasonId = (int)x.Episode.SeasonId,
                    Characters = _mapper.Map<List<MCharacter>>(ctx.EpisodeCharacters.Include(z => z.Character.CharacterMediaFile).Where(z => z.EpisodeId == x.Episode.Id).Select(x => x.Character).ToList())
                }).ToList();

                return query5;
            }

            else
            {
                var query6 = ctx.Episodes.Include(x => x.Season).Include(x => x.MediaFile).Include(x => x.EpisodesCharacters).Select(x => new MEpisode {
                    Id = x.Id,
                    MediaFile = _mapper.Map<MMediaFile>(x.MediaFile),
                    Title = x.Title,
                    AirDate = (DateTime)x.AirDate,
                    OverallNumberOfEpisode = (int)x.OverallNumberOfEpisode,
                    SeasonEpisodeNumber = x.SeasonEpisodeNumber,
                    Season = _mapper.Map<MSeason>(x.Season),
                    Summary = x.Summary,
                    Viewcount = x.Viewcount,
                    Characters = _mapper.Map<List<MCharacter>>(ctx.EpisodeCharacters.Include(z => z.Character.CharacterMediaFile).Where(z => z.EpisodeId == x.Id).Select(x => x.Character).ToList())

                }).ToList();

                return query6;
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
            
            var mostRecentEpisode = ctx.Episodes.OrderByDescending(x => x.Id).FirstOrDefault();
            if(mostRecentEpisode != null)
            {
                request.OverallNumberOfEpisode = mostRecentEpisode.OverallNumberOfEpisode + 1;

            }
            else
            {
                request.OverallNumberOfEpisode = 1;

            }
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

        public MEpisode Update(int id, EpisodeUserActivityRequest request)
        {
            var episode = ctx.Episodes.Find(id);
            episode.Viewcount += 1;
            ctx.SaveChanges();

            var activityCheck = ctx.UserEpisodeActivities?.Where(x => x.EpisodeId == request.EpisodeId && x.UserId == request.UserId)?.FirstOrDefault();
            if (activityCheck == null)
            {
                var newRecord = new UserEpisodeActivity { EpisodeId = request.EpisodeId, UserId = request.UserId };
                ctx.UserEpisodeActivities.Add(newRecord);
                ctx.SaveChanges();
            }
            return _mapper.Map<MEpisode>(episode);
        }

        public MEpisode Update(int id, EpisodeUpdateRequest request)
        {
            var episode = ctx.Episodes.Include(x => x.MediaFile).Include(x => x.EpisodesCharacters).Where(x => x.Id == id).FirstOrDefault();

            if(request.MainCharacters.Count > 0)
            {
                episode.EpisodesCharacters.Clear();
                foreach(var character in request.MainCharacters)
                {
                    episode.EpisodesCharacters.Add(new EpisodeCharacter
                    {
                        CharacterId = character.Id,
                        EpisodeId = episode.Id
                    });
                }
                ctx.SaveChanges();
            }

            if (request.AirDate != null)
            {
                episode.AirDate = request.AirDate;
            }

            if(request.Summary != "")
            {
                episode.Summary = request.Summary;
            }

            if (request.Title != "")
            {
                episode.Title = request.Title;
            }

            if(request.VideoUrl != "")
            {
                episode.MediaFile.Path = request.VideoUrl;
            }

            ctx.SaveChanges();

            return _mapper.Map<MEpisode>(episode);
        }
    }
}
