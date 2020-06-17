using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Location
    {
        public int Id { get; set; }

        [Required, MaxLength(75)]
        public string Name { get; set; }

        //public byte[] Image { get; set; }

        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }

        public ICollection<EpisodeLocation> EpisodesLocations { get; set; }

    }
}
