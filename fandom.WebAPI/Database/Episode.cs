using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Episode
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? OverallNumberOfEpisode { get; set; }

        public int? SeasonEpisodeNumber { get; set; }

        public DateTime AirDate { get; set; }

        public string Summary { get; set; }

        public int Viewcount { get; set; }

        public MediaFile MediaFile { get; set; }

        public int? SeasonId { get; set; }
        public Season Season { get; set; }

        public ICollection<UserEpisode> UsersEpisodes { get; set; }
        public ICollection<EpisodeCharacter> EpisodesCharacters { get; set; }


    }
}
