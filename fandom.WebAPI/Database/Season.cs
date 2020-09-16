using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Season
    {
        public int Id { get; set; }

        public int OrdinalNumber { get; set; }

        public DateTime PremiereDate { get; set; }

        public int NoOfEpisodes { get; set; }

        public string Summary { get; set; }

        public ICollection<Episode> Episodes { get; set; }



    }
}
