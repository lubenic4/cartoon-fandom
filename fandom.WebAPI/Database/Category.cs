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

        public string Title { get; set; }

        public string CategoryColor { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
