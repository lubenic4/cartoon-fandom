using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model
{
   public class MCharacter
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Biography { get; set; }

        public DateTime BirthDate { get; set; }

        public string Occupation { get; set; }

        public MCharacterMediaFile CharacterMediaFile { get; set; }

        public int FamilyId { get; set; }


    }
}
