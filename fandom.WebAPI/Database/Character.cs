using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Character
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Biography { get; set; }

        public int Age { get; set; }

        [Column("BirthDate", TypeName = "DateTime")]
        public DateTime BirthDate { get; set; }

        public string Occupation { get; set; }

        public CharacterMediaFile CharacterMediaFile { get; set; }

        public int? FamilyId { get; set; }
        public Family Family { get; set; }

        public int? ActorId { get; set; }
        public Actor Narator { get; set; }

        public ICollection<Content> AdditionalContent { get; set; }

        public ICollection<UserCharacter> UsersCharacters { get; set; }
        public ICollection<EpisodeCharacter> EpisodesCharacters { get; set; }



    }
}
