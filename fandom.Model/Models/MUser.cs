using fandom.Model.Models;
using System;
using System.Collections.Generic;

namespace fandom.Model
{
    public class MUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<MRole> Roles { get; set; }

        public List<MCharacter> FavouriteCharacters { get; set; }

        public List<MEpisode> FavouriteEpisodes { get; set; }
    }
}
