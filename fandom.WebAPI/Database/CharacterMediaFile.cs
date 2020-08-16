using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class CharacterMediaFile
    {
        public int Id { get; set; }

        public byte[] Thumbnail { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
