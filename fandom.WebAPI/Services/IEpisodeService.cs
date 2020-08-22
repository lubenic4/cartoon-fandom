using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public interface IEpisodeService
    {
        List<MEpisode> Get(EpisodesSeasonRequest request);

        MEpisode GetById(int episodeId);

        MEpisode Insert(EpisodeInsertRequest request);

        MEpisode Delete(int request);
    }
}
