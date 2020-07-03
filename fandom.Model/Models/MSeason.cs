using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Models
{
   public class MSeason
    {
        public int Id { get; set; }

        public int OrdinalNumber { get; set; }

        public DateTime PremiereDate { get; set; }

        public int NoOfEpisodes { get; set; }

        public string Summary { get; set; }
    }
}
