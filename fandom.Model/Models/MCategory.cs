using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Models
{
   public class MCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryColor { get; set; }

        public ICollection<MPost> Posts { get; set; }
    }
}
