using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Models
{
   public class MPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime CreationDate { get; set; }

        public MCategory Category { get; set; }

        public MUser User { get; set; }

        public List<MTag> Tags { get; set; }


    }
}
