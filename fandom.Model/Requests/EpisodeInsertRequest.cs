using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
    public class EpisodeInsertRequest
    {
        public string Title { get; set; }

        public int? OverallNumberOfEpisode { get; set; }

        public string Summary { get; set; }

        public DateTime AirDate { get; set; }

        public MMediaFile MediaFile { get; set; }

        public List<MCharacter> MainCharacters { get; set; }



    }
}
