using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Actor
    {
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        public string LastName { get; set; }

        //public byte[] Image { get; set; }

        public string Biography { get; set; }

        public int Age { get; set; }

        [Column("BirthDate", TypeName = "DateTime")]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string Occupation { get; set; }

        public string WikipediaLink { get; set; }

        public ICollection<Character> Narations { get; set; }
    }
}
