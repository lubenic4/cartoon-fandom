using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
    public class UserUpdateRequest
    {

        public MCharacter NewFavouriteCharacter { get; set; }

        public MEpisode NewFavouriteEpisode { get; set; }

        public bool ToAdd { get; set; }
    }
}
