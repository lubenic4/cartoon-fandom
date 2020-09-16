using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class MediaFile
    {
        public int MediaFileId { get; set; }

        public string FileName { get; set; }
        public string Path { get; set; }
        public byte[] Thumbnail { get; set; }

        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int? FamilyId { get; set; }
        public Family Family { get; set; }
    }
}
