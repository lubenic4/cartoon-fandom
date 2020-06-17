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

        [Required, MaxLength(20)]
        public string Title { get; set; }

        //public byte[] Thumbnail { get; set; }

        [Required]
        public int NoOfSeason { get; set; }

        [Required]
        public int OrdinalNumber { get; set; }

        [MaxLength(100)]
        public string Summary { get; set; }

        public string VideoLink { get; set; }

        public long Duration { get; set; }

        public int Viewcount { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public ICollection<UserEpisode> UsersEpisodes { get; set; }
        public ICollection<EpisodeSong> EpisodesSongs { get; set; }
        public ICollection<EpisodeLocation> EpisodesLocations { get; set; }
        public ICollection<EpisodeCharacter> EpisodesCharacters { get; set; }


    }
}
