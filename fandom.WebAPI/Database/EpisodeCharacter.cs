using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class EpisodeCharacter
    {
        public int EpisodeId { get; set; }

        public Episode Episode { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; }

    }
}
