using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
   public interface IBaseService<TModel, TSearch>
    {
        List<TModel> Get(TSearch search);

        TModel GetById(int id);
    }
}
