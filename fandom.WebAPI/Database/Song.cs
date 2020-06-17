using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Performer { get; set; }

        //public byte[] ImageCover { get; set; }

        public ICollection<EpisodeSong> EpisodesSongs { get; set; }

    }
}
