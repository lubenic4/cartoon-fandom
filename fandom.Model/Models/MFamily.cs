using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model
{
   public class MFamily
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MMediaFile MediaFile { get; set; }

        public ICollection<MCharacter> Members { get; set; }


    }
}
