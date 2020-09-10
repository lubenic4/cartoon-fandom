using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
   public interface IPostService
    {
        List<MPost> GetAll();
        MPost GetById(int id);
        MPost Insert(PostInsertRequest request);
        
    }
}
