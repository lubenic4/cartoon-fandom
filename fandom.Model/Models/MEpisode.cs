using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Models
{
   public class MEpisode
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //public byte[] Thumbnail { get; set; }

        public int OverallNumberOfEpisode { get; set; }

        public int SeasonEpisodeNumber { get; set; }

        public DateTime AirDate { get; set; }

        public string Summary { get; set; }

        public string VideoLink { get; set; }

        public long Duration { get; set; }

        public int Viewcount { get; set; }

        public bool IsAssignedToSeason { get; set; }

        public int SeasonId { get; set; }
        public MSeason Season { get; set; }

    }
}
