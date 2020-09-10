using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
   public class PostInsertRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public MCategory Category { get; set; }
        public List<MTag> Tags { get; set; }
        public DateTime CreationDate { get; set; }
        public MUser PostOwner { get; set; }
    }
}
