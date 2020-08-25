using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
    public class EpisodesSeasonRequest
    {
        public int? SeasonId { get; set; }

        public bool? isAssigned { get; set; }

        public List<int> EpisodesIds { get; set; }
    }
}
