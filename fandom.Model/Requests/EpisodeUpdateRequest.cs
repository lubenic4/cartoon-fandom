using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
    public class EpisodeUpdateRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime AirDate { get; set; }
        public List<MCharacter> MainCharacters { get; set; }
        public string VideoUrl { get; set; }
    }
}
