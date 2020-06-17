using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //public byte[] Icon { get; set; }

        public ICollection<PostTag> PostsTags { get; set; }

    }
}
