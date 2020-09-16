using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }



        public ICollection<Post> Posts { get; set; }

        public ICollection<UserRole> UsersRoles { get; set; }

        public ICollection<UserEpisode> UsersEpisodes { get; set; }

        public ICollection<UserCharacter> UsersCharacters { get; set; }


    }
}
