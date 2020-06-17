using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Title { get; set; }

        //public byte[] Icon { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
